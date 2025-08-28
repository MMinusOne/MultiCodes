#pragma once

using namespace System;
using namespace System::Collections::Generic;

namespace  Bridge {

	public ref class ItemNode {
	public:
		String^ path;
		String^ Name;
		bool isDirectory;
		List <ItemNode^>^ Children = gcnew List<ItemNode^>();
	};

	public ref class FileManagerBridge {
	public:
		ItemNode^ createProjectTree(String^ directory);
	};

	public ref class ConsoleBridge {
	public:
		String^ read();
		void execute(String^ command);
		List<String^>^ readBlocks();
	};
}
