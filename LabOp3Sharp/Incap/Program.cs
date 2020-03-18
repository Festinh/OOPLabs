using System;

namespace Incap
{
    class Program
    {
        static void Main(string[] args)
        {
            Text one = new Text(2);
            one.Add(0, 0, '1');
            one.Add(0, 1, 'a');
            one.Add(1, 0, '2');
            one.Add(1, 1, 'b');
            Console.WriteLine(one.VowelCount);
            Console.WriteLine(one[0]);
            Console.WriteLine(one[1]);
        }

        class Text
        {
            private char[,] symbols;
            private int vowelCount;
            private string output;

            public Text(int size)
            {
                symbols = new char[size, size];
            }

            public char[,] Symbols
            {
                get => symbols;
                set => symbols = value;
            }

            public void Add(int row, int col, char value)
            {
                symbols[row, col] = value;
                if (value == 65 || value == 69 || value == 73 || value == 79 || value == 85 || value == 89 || value == 97 || value == 101 || value == 105 || value == 111 || value == 117 || value == 121) vowelCount++;
                return;
            }

            public string this[int index]
            {
                get
                {
                    if (index == 0)
                    {
                        output = "";
                        for (int i = 0; i < symbols.GetUpperBound(0) + 1; i++)
                            output += symbols[i, i];
                        return output;
                    }
                    else if (index == 1)
                    {
                        output = "";
                        for (int i = 0; i < symbols.GetUpperBound(0) + 1; i++)
                            output += symbols[i, symbols.GetUpperBound(0)-i];
                        return output;
                    }
                    else return "";
                }
            }
            public int VowelCount
            {
                get => vowelCount;
            }
        }
    }
}
