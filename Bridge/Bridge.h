#pragma once

using namespace System;
using namespace System::Collections::Generic;

namespace  Bridge {

	public ref class ItemNodeBridge {
	public:
		String^ path;
		String^ Name;
		bool isDirectory;
		List <ItemNodeBridge^>^ Children = gcnew List<ItemNodeBridge^>();
	};

	public ref class FileManagerBridge {
	public:
		ItemNodeBridge^ createProjectTree(String^ directory);
		void createFile(String^ path, String^ fileName);
		void createFolder(String^ path, String^ folderName);
		void deletePath(String^ path);
		String^ readFile(String^ path);
		void saveFile(String^ path, String^ code);
	};

	public ref class ConsoleBridge {
	public:
		String^ read();
		void execute(String^ dir, String^ command);
		List<String^>^ readBlocks();
	};
}
