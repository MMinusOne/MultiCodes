#include <filesystem>
using namespace std::filesystem;
#include "ItemNode.h"

 
__stdcall ItemNode::ItemNode(path itemPath) {
	this->itemPath = itemPath;
}

void __stdcall ItemNode::addChild(ItemNode& itemNode) {
	this->children.push_back(itemNode);
}