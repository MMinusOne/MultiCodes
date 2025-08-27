#include <string>
#include <memory>
#include <stdexcept>
#include <cstdio>
#include <array>
#include "Console.h"


ConsoleNative& __stdcall ConsoleNative::getInstance() {
	static ConsoleNative instance;
	return instance;
}

std::string __stdcall ConsoleNative::read() {
	return consoleText;
}

std::string __stdcall ConsoleNative::execute(const char* command) {
	std::array<char, 128> buffer;
	std::string result;

	std::unique_ptr<FILE, decltype(&_pclose)> pipe(_popen(command, "r"), _pclose);
	if (!pipe) {
		throw std::runtime_error("popopen() failed");
	}

	while (fgets(buffer.data(), buffer.size(), pipe.get()) != nullptr) {
		result += buffer.data();
		consoleText += buffer.data();
	}

	return result;
}


