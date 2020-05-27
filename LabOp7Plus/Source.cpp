#include <iostream>
#include "Collection.h"

using namespace std;

int main()
{
    float a = 5.3F;
    float b = 2.1F;
    float c = 6.1F;
    float j[] = { 2.1F, -6.2F, 5.3F, 6.1F, 5.3F, -2.6F };
    int size = sizeof(j) / sizeof(j[0]);
    Collection my(j, size);
    cout << my.CalcNumberOfNumbers(my.CalcSum()) << endl;
    my.ExcludeNegativeNumbers();
}