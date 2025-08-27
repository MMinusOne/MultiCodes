#pragma once
class __declspec(dllexport) ConsoleNative
{
    std::string consoleText;
public:
    static ConsoleNative& getInstance();
    std::string read();
    std::string execute(const char* command);
};

