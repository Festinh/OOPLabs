#pragma once
#include "Str.h"
#include <iostream>

using namespace std;

class LetterStr : public Str
{
public:
	LetterStr(const char s[])
	{
        char* temp = new char[strlen(s)];
        int counter1 = 0, counter2 = 0;
        for (int i = 0; i < strlen(s); i++)
        {
            if (s[i] > 96 && s[i] < 123 || s[i] > 64 && s[i] < 91)
            {
                temp[counter1] = s[i];
                counter1++;
            }
            else
            {
                counter2++;
            }
        }
        str = new char[strlen(temp) - counter2];
        size = strlen(str);
        for (int j = 0; j < size; j++)
        {
            str[j] = temp[j];
        }
	}

    char* getStr()
    {
        return str;
    }

    void print()
	{
		int i = 0;
		while (i < size)
		{
			cout << str[i];
			i++;
		}
		cout << endl;
	}

    void moveRight()
    {
        char temp = str[size - 1];
        for (int i = size - 1; i > 0; i--)
        {
            str[i] = str[i - 1];
        }
        str[0] = temp;
    }
};