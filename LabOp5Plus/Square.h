#pragma once
#include "Figure.h"

class Square : public Figure
{
	double x1, x2, x3, x4, y1, y2, y3, y4;
	double side[6] = { 0, 0, 0, 0, 0, 0 };
public:
	Square(double X1, double Y1, double X2, double Y2, double X3, double Y3, double X4, double Y4)
	{
		side[0] = sqrt((X2 - X1) * (X2 - X1) + (Y2 - Y1) * (Y2 - Y1));
		side[1] = sqrt((X3 - X2) * (X3 - X2) + (Y3 - Y2) * (Y3 - Y2));
		side[2] = sqrt((X4 - X3) * (X4 - X3) + (Y4 - Y3) * (Y4 - Y3));
		side[3] = sqrt((X1 - X4) * (X1 - X4) + (Y1 - Y4) * (Y1 - Y4));
		side[4] = sqrt((X1 - X3) * (X1 - X3) + (Y1 - Y3) * (Y1 - Y3));
		side[5] = sqrt((X2 - X4) * (X2 - X4) + (Y2 - Y4) * (Y2 - Y4));

        int i = 0;
        while (i < 4)
        {
            if (side[i] == side[i + 1]) i++;
            else
            {
                i++;
                break;
            }
        }

        if (i == 4)
        {
            if (side[4] == side[5])
            {
                x1 = X1;
                x2 = X2;
                x3 = X3;
                x4 = X4;
                y1 = Y1;
                y2 = Y2;
                y3 = Y3;
                y4 = Y4;
            }
        }
        else
        {
            x1 = 0;
            x2 = 0;
            x3 = 0;
            x4 = 0;
            y1 = 0;
            y2 = 0;
            y3 = 0;
            y4 = 0;

            side[0] = side[1] = side[2] = side[3] = side[4] = side[5] = 0;
        }
	}

    double Area() override
    {
        return side[0] * side[0];
    }

    double Perimeter() override
    {
        return 4 * side[0];
    }
};