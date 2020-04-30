using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace ConsoleApp1
{
    class Expression
    {
        private double a, b, c, d;

        public Expression(double a, double b, double c, double d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }


        public double Calculating()
        {
            return Divide(ln(a * b + 2) * c, 41 - Divide(b, c) + 1);
        }

        private double ln(double a)
        {
            double res = 0;
            try
            {
                if (a < 1) throw new ArithmeticException();
                res = Math.Log(a);
            }
            catch (Exception exp)
            {

                using (TextWriter log = new StreamWriter(@"D:\Programming\C# Projects\LabOp6Sharp\log.txt", true, System.Text.Encoding.Default))
                {
                    log.WriteLine("Natural logarithm error! Info: " + exp.Message + DateTime.Now);
                }
            }
            return res;
        }

        private double Divide(double a, double b)
        {
            double res = 0;
            try
            {
                if (b == 0) throw new DivideByZeroException();
                res = a / b;
            }
            catch (Exception exp)
            {
                using (TextWriter logExp = new StreamWriter(@"D:\Programming\C# Projects\LabOp6Sharp\log.txt", true, System.Text.Encoding.Default))
                {
                    logExp.WriteLine("Division by zero error! Info: " + exp.Message + DateTime.Now);
                }
            }
            return res;
        }

        public static double operator /(Expression expr, double number)
        {
            double res = 0;

            try
            {
                if (number == 0) throw new Exception("Dividing by zero error");
                res = expr.a / number;
            }
            catch (Exception e)
            {
                using (TextWriter logExp = new StreamWriter(@"D:\Programming\C# Projects\LabOp6Sharp\log.txt", true, System.Text.Encoding.Default))
                {
                    logExp.WriteLine("Division by zero error! Info: " + e.Message + DateTime.Now);
                }
            }
            return res;
        }
    }
}
