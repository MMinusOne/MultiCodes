#include <string>
#include <memory>
#include <stdexcept>
#include <cstdio>
#include <array>
#include <thread>
#include <atomic>
#include <vector>
#include <iostream>
#include <queue>
#include <condition_variable>
#include <mutex>
#include "Console.h";

ConsoleNative::ConsoleNative() : consoleText("") {
	std::thread(&ConsoleNative::executeState, this).detach();
}

ConsoleNative& __stdcall ConsoleNative::getInstance() {
	static ConsoleNative instance;
	return instance;
}

std::string __stdcall ConsoleNative::read() {
	std::lock_guard<std::mutex> lock(queueMutex);
	return consoleText;
}

void __stdcall ConsoleNative::execute(const std::string& command) {
	{
		std::lock_guard<std::mutex> lock(queueMutex);
		this->commands.push(command);
	}

	condition.notify_one();
}

void __stdcall ConsoleNative::executeState() {
	while (isRunning) {
		std::string command;

		{
			std::unique_lock<std::mutex> lock(queueMutex);
			condition.wait(lock, [this] {return !commands.empty() || !isRunning; });

			if (!isRunning) break;

			command = std::move(commands.front());
			commands.pop();
		}

		std::array<char, 128> buffer;
		std::string result;

		FILE* pipe = _popen(command.c_str(), "r");

		if (!pipe) {
			{
				std::lock_guard<std::mutex> lock(queueMutex);
				consoleText += "PIPE ERROR";
			}
			continue;
		}

		while (fgets(buffer.data(), buffer.size(), pipe) != nullptr) {
			result += buffer.data();
			consoleText += buffer.data();
		}

		{
			std::lock_guard<std::mutex> lock(queueMutex);
			consoleText += result;
		}
	}

}

ConsoleNative::~ConsoleNative() {
	isRunning = false;
	condition.notify_all();
}