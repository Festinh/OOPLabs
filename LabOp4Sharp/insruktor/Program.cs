using System;

namespace insruktor
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] pip = { 'a', 'g', 'r' };
            str CB1 = new str();
            str CB2 = new str(pip);
            str CB3 = new str(CB2);
            CB3 *= 2;
            Console.WriteLine(CB3.getLine());
            CB1 = CB2 + CB3;
            Console.WriteLine(CB1.getLine());
        }


        public class str
        {
            private char[] line;

            public str()
            {
                line = new char[] { };
            }

            public str(char[] s)
            {
                line = new char[s.Length];
                s.CopyTo(line, 0);
            }

            public str(int s)
            {
                line = new char[s];

            }

            public str(str val) : this(val.line) { }

            public int len()
            {
                return line.GetLength(0);
            }

            public char[] getLine() 
            { 
                return line; 
            }

            public static str operator +(str lineFirst, str lineSecond)
            {
                str result = new str(lineFirst.len() + lineSecond.len());
                for (int i = 0; i < result.len(); i++)
                {
                    if (i < lineFirst.len())
                        result.line[i] = lineFirst.line[i];
                    else
                        result.line[i] = lineSecond.line[i - lineFirst.len()];
                }
                return result;
            }

            public static str operator *(str inputLine, int n)
            {
                str result = new str(inputLine.len() * n);
                for (int i = 0; i < inputLine.len(); i++)
                {
                    for (int j = 0; j < n; j ++)
                    {
                        result.line[n * i + j] = inputLine.line[i];
                    }
                }
                return result;
            }
        }
    }
}
