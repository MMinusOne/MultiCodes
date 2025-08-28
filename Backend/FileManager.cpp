#include <filesystem>
#include <vector>
#include <string>
#include <functional>
#include <fstream>
#include "FileManager.h"
#include "ItemNode.h"

using namespace std::filesystem;

void traverseDirectory(std::string directory, ItemNodeNative* tree) {
	for (auto& item : directory_iterator(directory)) {
		auto path = item.path().string();

		if (is_directory(item)) {
			ItemNodeNative* itemNode = new ItemNodeNative(path);
			itemNode->setIsDirectory();
			traverseDirectory(path, itemNode);
			tree->addChild(*itemNode);
		}
		else {
			ItemNodeNative* itemNode = new ItemNodeNative(path);
			tree->addChild(*itemNode);
		}
	}
}

ItemNodeNative* __stdcall FileManager::createProjectTree(std::string directory) {
	ItemNodeNative* rootNode = new ItemNodeNative(directory);

	traverseDirectory(directory, rootNode);

	return rootNode;
}

void __stdcall FileManager::createFile(std::string path, std::string fileName) {
	std::string fullPath = path + fileName;

	std::ofstream file(fullPath);
}

void __stdcall FileManager::createFolder(std::string path, std::string folderName) {
	std::string fullPath = path + folderName;

	std::filesystem::path folder(fullPath);
}
void __stdcall FileManager::deletePath(std::string path) {
	std::filesystem::remove(path);
}