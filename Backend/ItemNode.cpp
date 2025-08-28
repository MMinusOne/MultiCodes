#include <filesystem>
using namespace std::filesystem;
#include "ItemNode.h"

 
__stdcall ItemNodeNative::ItemNodeNative(std::string itemPath) {
	this->itemPath = itemPath;
	
	std::string reversedName;
	
	for (int i = itemPath.size()-1; i >= 0; i--) {
		if (itemPath[i] == '\\') break;

		reversedName += itemPath[i];
	}
	
	std::string correctedName;

	for (int i = reversedName.size() - 1; i >= 0; i--) {
		correctedName += reversedName[i];
	}

	this->name = correctedName;
}

void __stdcall ItemNodeNative::addChild(ItemNodeNative& itemNode) {
	this->children.push_back(itemNode);
}

void __stdcall ItemNodeNative::setIsDirectory() {
	this->isDirectory = true;
}

std::vector<ItemNodeNative> __stdcall ItemNodeNative::getChildren() {
	return this->children;
}

bool __stdcall ItemNodeNative::getIsDirectory() {
	return isDirectory;
}