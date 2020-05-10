using System;
using LabOp8SharpLib;

namespace LabOp8Sharp
{
    delegate int lettersDelegate(string str);
    class Program
    {

        static int letters(string str)
        {
            int s = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 97 && str[i] <= 122)
                {
                    s++;
                }
            }
            return s;
        }

        static void Main(string[] args)
        {
            lettersDelegate mydelegate = letters;
            Console.WriteLine("Number of lowercase letters = {0}", mydelegate("I'm not a clown"));

            Car MaybachS600 = new Car(56);
            MaybachS600.move(30, 70);
        }
    }
}
