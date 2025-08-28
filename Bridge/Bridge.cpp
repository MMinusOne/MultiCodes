#include <msclr/marshal_cppstd.h>
#include "Bridge.h"
#include <vector>
#include <string>
#include "FileManager.h";
#include "Console.h";

using namespace System;
using namespace System::Collections::Generic;
using namespace msclr::interop;
using FileManagerBridge = Bridge::FileManagerBridge;
using ConsoleBridge = Bridge::ConsoleBridge;

auto fileManagerNative = new FileManager();
ConsoleNative& consoleNativeInstance = ConsoleNative::getInstance();

String^ ConsoleBridge::read() {
	auto consoleText = consoleNativeInstance.read();
	return msclr::interop::marshal_as<String^>(consoleText);
}

List<String^>^ ConsoleBridge::readBlocks() {
	auto consoleBlocksNative = consoleNativeInstance.readBlocks();
	auto consoleBlocks = gcnew List<String^>();

	for (auto& consoleBlock : consoleBlocksNative) {
		consoleBlocks->Add(msclr::interop::marshal_as<String^>(consoleBlock));
	}

	return consoleBlocks;
}

void ConsoleBridge::execute(String^ command) {
	auto commandNative = msclr::interop::marshal_as<std::string>(command);
	consoleNativeInstance.execute(commandNative.c_str());
}

void traverseTree(ItemNodeNative* nativeTree, Bridge::ItemNodeBridge^ rootTree) {
	for (auto& child : nativeTree->getChildren()) {
		if (child.getIsDirectory()) {
			Bridge::ItemNodeBridge^ itemNode = gcnew Bridge::ItemNodeBridge();
			itemNode->path = msclr::interop::marshal_as<String^>(child.getPath());
			itemNode->Name = msclr::interop::marshal_as<String^>(child.getName());
			itemNode->isDirectory = true;
			traverseTree(&child, itemNode);
			rootTree->Children->Add(itemNode);
		}
		else {
			Bridge::ItemNodeBridge^ itemNode = gcnew Bridge::ItemNodeBridge();
			itemNode->path = msclr::interop::marshal_as<String^>(child.getPath());
			itemNode->Name = msclr::interop::marshal_as<String^>(child.getName());
			rootTree->Children->Add(itemNode);
		}
	}
}

Bridge::ItemNodeBridge^ FileManagerBridge::createProjectTree(String^ directory) {
	auto directoryTreeNative = fileManagerNative->createProjectTree(msclr::interop::marshal_as<std::string>((String^)directory));
	ItemNodeBridge^ rootTree = gcnew Bridge::ItemNodeBridge();

	traverseTree(directoryTreeNative, rootTree);

	return rootTree;
}