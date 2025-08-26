#include <msclr/marshal_cppstd.h>
#include "Bridge.h"
#include <vector>
#include <string>
#include "FileManager.h";

using namespace System;
using namespace System::Collections::Generic;
using namespace msclr::interop;
using FileManagerBridge = Bridge::FileManagerBridge;


auto fileManagerNative = new FileManager();

List<Bridge::ItemNode^>^ FileManagerBridge::readDirectory(String^ directory) {
	auto directoryTree = gcnew List<Bridge::ItemNode^>();
	auto directoryTreeNative = fileManagerNative->readDirectory(msclr::interop::marshal_as<std::string>((String^)directory));
	

	return directoryTree;
}	