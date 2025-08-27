#include <string>
#include <memory>
#include <stdexcept>
#include <cstdio>
#include <array>
#include <thread>
#include <vector>
#include <iostream>
#include <mutex>
#include "Console.h";

ConsoleNative::ConsoleNative() : consoleText("") {
}

ConsoleNative& __stdcall ConsoleNative::getInstance() {
	static ConsoleNative instance;
	return instance;
}

std::string __stdcall ConsoleNative::read() {
	return consoleText;
}

std::vector<std::string> __stdcall ConsoleNative::readBlocks() {
	return consoleBlocks;
}

void __stdcall ConsoleNative::execute(const std::string& command) {
	std::array<char, 128> buffer;
	std::string result;

	std::unique_ptr<FILE, decltype(&_pclose)> pipe(_popen(command.c_str(), "r"), _pclose);
	if (!pipe) {
		throw std::runtime_error("popopen() failed");
	}

	std::string currentBlock;

	while (fgets(buffer.data(), buffer.size(), pipe.get()) != nullptr) {
		result += buffer.data();
		consoleText += buffer.data();
		currentBlock += buffer.data();
	}
	consoleBlocks.push_back(currentBlock);

}


ConsoleNative::~ConsoleNative() {
}