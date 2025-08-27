#pragma once
#include "ItemNode.h"
#include <filesystem>
#include <vector>
#include <string>
class __declspec(dllexport) FileManager
{
public:
	std::vector<ItemNode> createProjectTree(std::string directoryPath);
};

