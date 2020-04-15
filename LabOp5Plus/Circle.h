#pragma once
#include "Figure.h"

class Circle : public Figure
{
    double radius;
public:
    Circle(double r)
    {
        radius = r;
    }
    double Area() override
    {
        return 3.14159 * radius * radius;
    }
    double Perimeter() override
    {
        return 3.14159 * 2 * radius;
    }
};