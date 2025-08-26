#pragma once
class __declspec(dllexport) FileManager
{
public:
	std::vector<std::string> __stdcall readDirectory(std::string directory);
};

