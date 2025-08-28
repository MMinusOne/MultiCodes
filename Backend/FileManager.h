#pragma once
#include "ItemNode.h"
#include <filesystem>
#include <vector>
#include <string>
class __declspec(dllexport) FileManager
{
public:
	ItemNodeNative* createProjectTree(std::string directoryPath);
	void createFile(std::string path, std::string fileName);
	void createFolder(std::string path, std::string folderName);
	void deletePath(std::string path);
	std::string readFile(std::string path);
	void saveFile(std::string path, std::string code);
};

