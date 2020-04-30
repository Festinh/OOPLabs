#include "Expression.h"

int main()
{
    Expression exps[] = { Expression(1, -3, 0, 1), Expression(1, 2, 0, 3), Expression(1, 1, 0, 0) };
    
    cout << "Calculating exps[0] = " << exps[0].Calculating() << endl;
    cout << "Calculating exps[1] = " << exps[1].Calculating() << endl;
    cout << "Calculating exps[2] = " << exps[2].Calculating() << endl;
}