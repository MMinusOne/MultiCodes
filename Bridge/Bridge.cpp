#include "Bridge.h"
//#include "FileManager.h";

using namespace System;
using namespace System::Collections::Generic;
using FileManagerBridge = Bridge::FileManagerBridge;

List<Bridge::ItemNode^>^ FileManagerBridge::readDirectory(String^ directory) {
	auto directoryTree = gcnew List<Bridge::ItemNode^>();

	return directoryTree;
}	