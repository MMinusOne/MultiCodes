#pragma once
#include <string>
#include <memory>
#include <stdexcept>
#include <cstdio>
#include <array>
#include <thread>
#include <vector>
#include <iostream>

class __declspec(dllexport) ConsoleNative
{
    std::string consoleText;
    std::vector<std::string> consoleBlocks;
    std::vector<std::string> commands;

public:
    ConsoleNative();
    static ConsoleNative& getInstance();
    std::string read();
    void execute(const std::string& command);
    std::vector<std::string> readBlocks();
    ~ConsoleNative();
};

