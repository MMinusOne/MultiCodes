#pragma once
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
#include <sstream>
#include <sys/types.h>

class __declspec(dllexport) ConsoleNative
{
    std::string consoleText;
    std::queue<std::string> commands;
    bool isRunning = true;
    std::mutex queueMutex;
    std::condition_variable condition;
    std::thread workerThread;

public:
    ConsoleNative();
    static ConsoleNative& getInstance();
    std::string read();
    void execute(const std::string& command);
    void executeState();
    ~ConsoleNative();
};

