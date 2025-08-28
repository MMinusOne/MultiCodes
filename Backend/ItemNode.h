#pragma once
#include <filesystem>
#include <vector>
#include <string>

using namespace std::filesystem;

class __declspec(dllexport) ItemNodeNative
{
	std::string itemPath;
	std::string name;
	std::vector<ItemNodeNative> children;
	bool isDirectory;
public:
	__stdcall ItemNodeNative(std::string itemPath);
	std::string __stdcall getPath() { return itemPath; };
	void __stdcall addChild(ItemNodeNative& childNode);
	std::vector<ItemNodeNative> __stdcall getChildren();
	bool __stdcall getIsDirectory();
	std::string __stdcall getName() { return name; }
	void __stdcall setIsDirectory();
};

