using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression[] exps = { new Expression(1, -3, 0, 1), new Expression(1, 2, 0, 3), new Expression(1, 1, 0, 0) };


            Console.WriteLine("Calculating exps[0] = " + exps[0].Calculating());
            Console.WriteLine("Calculating exps[1] = " + exps[1].Calculating());
            Console.WriteLine("Calculating exps[2] = " + exps[2].Calculating());
        }
    }
}


