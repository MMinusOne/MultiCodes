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

List<Bridge::ItemNode^>^ FileManagerBridge::createProjectTree(String^ directory) {
	auto directoryTree = gcnew List<Bridge::ItemNode^>();
	auto directoryTreeNative = fileManagerNative->createProjectTree(msclr::interop::marshal_as<std::string>((String^)directory));


	return directoryTree;
}