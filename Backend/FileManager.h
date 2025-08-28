#pragma once
#include "ItemNode.h"
#include <filesystem>
#include <vector>
#include <string>
class __declspec(dllexport) FileManager
{
public:
	ItemNodeNative* createProjectTree(std::string directoryPath);
};

