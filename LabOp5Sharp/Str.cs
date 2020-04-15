using System;
using System.Collections.Generic;
using System.Text;

namespace LabOp5Sharp
{
    class Str
    {
        protected char[] str;
        public Str()
        {
            str = new char[1];
        }

        public int sizeStr()
        {
            return str.Length;
        }
    }
}
