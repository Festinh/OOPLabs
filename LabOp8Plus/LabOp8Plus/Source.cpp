#include <iostream>
#include "Car.h"
#include <string>

using namespace std;

int letters(string str)
{
    int s = 0;
    for (int i = 0; i < str.size(); i++)
    {
        if (str[i] >= 97 && str[i] <= 122)
        {
            s++;
        }
    }
    return s;
}

int (*Lett)(string str);

int main()
{
    Lett = letters;
    cout << "Number of lowercase letters = " << Lett("I'm not a clown") << endl;

	Car MaybachS600(56);
	MaybachS600.move(30, 70);
}	