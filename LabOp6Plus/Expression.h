#pragma once
#include <iostream>
#include "math.h"
#include <fstream>
#include <time.h>
#include <locale.h>

using namespace std;

class Expression
{
	double a, b, c, d;
public:
    Expression(double a, double b, double c, double d)
    {
        this -> a = a;
        this -> b = b;
        this -> c = c;
        this -> d = d;
    }

    double getA() { return a; }
    double getB() { return b; }
    double getC() { return c; }

    void setA(int x) { a = x; }
    void setB(int x) { b = x; }
    void setC(int x) { c = x; }


    double Calculating()
    {
        return Divide(ln(a * b + 2) * c, 41 - Divide(b, c) + 1);
    }

    double ln(double a)
    {
        double res = 0;
        try
        {
            if (a < 1) throw runtime_error("Natural logarithm error");
            res = log(a);
        }
        catch (runtime_error exp)
        {
            ofstream out("log.txt", ios::app);
            if (out.is_open())
            {
                out << exp.what() << time << endl;
            }
            out.close();
        }
        return res;
    }

    double Divide(double a, double b)
    {
        double res = 0;
        try
        {
            if (b == 0) throw runtime_error("Division by zero error");
            res = a / b;
        }
        catch (runtime_error exp)
        {
            ofstream out("log.txt", ios::app);
            if (out.is_open())
            {
                out << exp.what() << endl;
            }
            out.close();
        }
        return res;
    }

    double operator /(double number)
    {
        double res = 0;

        try
        {
            if (number == 0) throw runtime_error("Division by zero error");
            res = a / number;
        }
        catch (runtime_error e)
        {
            cout << e.what() << time << endl;
        }
        return res;
    }
};