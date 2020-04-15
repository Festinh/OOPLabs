using System;

namespace LabOp5Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Square ayaya = new Square(0, 1, 1, 1, 1, 0, 0, 0);
            Console.WriteLine(ayaya.Area());
            Console.WriteLine(ayaya.Perimeter());
            char[] bb = { 'y', 'T', '2', 'h', 'i', 'f' };
            LetterStr a = new LetterStr(bb);
            a.moveRight();
            Console.WriteLine(a.getStr());
        }
    }
}
