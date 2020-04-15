#include "LetterStr.h"
#include "Square.h"
#include "Circle.h"

using namespace std;

int main()
{
    Square ayaya(0, 1, 1, 1, 1, 0, 0, 0);
    cout << ayaya.Area() << endl;
    cout << ayaya.Perimeter() << endl;
    LetterStr a("yT2hif");
    a.moveRight();
    a.print();
}