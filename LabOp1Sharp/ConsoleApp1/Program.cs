using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Comparison(int a, int b, ref bool res)
        {
            int abinar, bbinar, ibinar;
            for (int i = 0; i < 32; i++)
            {
                ibinar = 1 << i;
                abinar = a & ibinar;
                bbinar = b & ibinar;
                if (System.Convert.ToBoolean(abinar ^ bbinar))
                {
                    res = false;
                    break;
                }
                else
                {
                    res = true;
                }
            }
        }
        static int adding(int a, int b)
        {
            int result = 0;
            int abinar, bbinar, cbinar = 0, nbinar;
            int bits = 32;

            for (int n = 0; n < bits; ++n)
            {
                nbinar = 1 << n;
                abinar = a & nbinar;
                bbinar = b & nbinar;
                if (System.Convert.ToBoolean(abinar ^ bbinar))
                {
                    result |= ~cbinar & nbinar;
                }
                else if (System.Convert.ToBoolean(abinar))
                {
                    result |= cbinar;
                    cbinar = nbinar;
                }
                else
                {
                    result |= cbinar;
                    cbinar = 0;
                }
                cbinar <<= 1;
            }
            return result;
        }
        

        static void Main(string[] args)
        {
            bool res = false;
            int a = -43, b = -43;
            Comparison(a, b, ref res);
            Console.WriteLine(res);
            Console.WriteLine(adding(a, b));
        }
    }
}