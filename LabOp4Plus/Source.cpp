#include <iostream>

using namespace std;

class Strin
{
	int size = 0;
	char* str = nullptr;
public:
	Strin() = default;

	Strin(int s)
	{
		size = s;
		str = new char[size];
	}

	Strin(const char val[])
	{
		size = strlen(val);
		str = new char[size];
		for (int i = 0; i < size; i++)
		{
			str[i] = val[i];
		}
	}

	Strin(const Strin& object)
	{
		size = object.size;
		str = new char[size];
		for (int i = 0; i < size; i++)
		{
			str[i] = object.str[i];
		}
	}

	int len()
	{
		return size;
	}

	char* getLine() 
	{
		return str;
	}

	const Strin operator+(const Strin object)
	{
		Strin result(size + object.size);
		for (int i = 0; i < result.size; i++)
		{
			if (i < size)
				result.str[i] = str[i];
			else
				result.str[i] = object.str[i - size];
		}
		return result;
	}

	const Strin operator*(int n)
	{
		Strin result(size * n);
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < n; j++)
			{
				result.str[n * i + j] = str[i];
			}
		}
		return result;
	}

	void print()
	{
		for (int i = 0; i < size; i++)
		{
			cout << str[i];
		}
		cout << endl;
	}
};

int main() 
{
	Strin CB2("agr");
	Strin CB3(CB2);
	Strin CB4(CB3 * 2);
	cout << CB2.len() << endl;
	CB2.print();
	CB3.print();
	CB4.print();
	Strin CB1(CB2 + CB4);
	CB1.print();
	
}
