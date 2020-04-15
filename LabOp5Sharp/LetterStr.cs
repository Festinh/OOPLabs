using System;
using System.Collections.Generic;
using System.Text;

namespace LabOp5Sharp
{
    class LetterStr: Str
    {
        public LetterStr(char[] s)
        {
            char[] temp = new char[s.Length];
            int counter1 = 0, counter2 = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] > 96 && s[i] < 123 || s[i] > 64 && s[i] < 91)
                {
                    temp[counter1] = s[i];
                    counter1++;
                }
                else
                {
                    counter2++;
                }
            }
            str = new char[temp.Length-counter2];
            for (int j = 0; j < str.Length; j++)
            {
                str[j] = temp[j];
            }
        }

        public char[] getStr()
        {
            return str;
        }

        public void moveRight()
        {
            char temp = str[str.Length-1];
            for (int i = str.Length-1; i > 0; i--)
            {
                    str[i] = str[i - 1];
            }
            str[0] = temp;
        }
    }
}
