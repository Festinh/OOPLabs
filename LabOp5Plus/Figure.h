#pragma once
#include <iostream>

class Figure
{
public:
	virtual double Area()
	{
		return 0;
	}
	virtual double Perimeter()
	{
		return 0;
	}
};