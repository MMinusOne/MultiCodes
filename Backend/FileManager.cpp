#include <filesystem>
#include <vector>
#include <string>
#include <functional>
#include "FileManager.h"
#include "ItemNode.h"

using namespace std::filesystem;


void __stdcall traverseDirectory(path directory, ItemNode& parent) {
	for (const auto& item : directory_iterator(directory)) {
		if (is_directory(item)) {
			auto dirTree = new ItemNode(item);
			traverseDirectory(item, *dirTree);
			parent.addChild(*dirTree);
		}
		else {
			auto itemNode = new ItemNode(item);
			parent.addChild(*itemNode);
		}
	}
}

std::vector<ItemNode> __stdcall FileManager::createProjectTree(std::string directory) {
	std::vector<ItemNode> tree = {};

	traverseDirectory(directory, tree[0]);

	return tree;
}