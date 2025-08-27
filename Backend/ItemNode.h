#pragma once
#include <filesystem>
#include <vector>
#include <string>

using namespace std::filesystem;

class __declspec(dllexport) ItemNode
{
	path itemPath;
	std::string name;
	std::vector<ItemNode> children;
public:
	__stdcall ItemNode(path itemPath);
	void __stdcall addChild(ItemNode& childNode);
};

