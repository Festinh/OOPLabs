using System;

namespace LabOp7Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            float a = 5.3F;
            float b = 2.1F;
            float c = 6.1F;
            float[] j = { 2.1F, -6.2F, 5.3F, 6.1F, 5.3F, -2.6F };
            Collection my = new Collection(j);
            Console.WriteLine(my.CalcNumberOfNumbers(my.CalcSum()));
            my.ExcludeNegativeNumbers();
        }
    }
}
