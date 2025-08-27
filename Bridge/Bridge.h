#pragma once

using namespace System;
using namespace System::Collections::Generic;

namespace  Bridge {

	public ref class ItemNode {
	public:
		String^ fileName;
		List <ItemNode^> children;
	};

	public ref class FileManagerBridge {
	public:
		List<ItemNode^>^ createProjectTree(String^ directory);
	};

	public ref class ConsoleBridge {
	public:
		String^ read();
		String^ execute(String^ command);
	};
}
