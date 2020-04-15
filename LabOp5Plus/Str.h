#pragma once
#include <iostream>
using namespace std;

class Str
{
protected:
	int size = 0;
	char* str = nullptr;
public:
	Str() = default;

	Str(const char s[])
	{
		size = strlen(s);
		str = new char[size];
		for (int i = 0; i < size; i++)
		{
			str[i] = s[i];
		}
	}

	int sizeStr()
	{
		return size;
	}
};