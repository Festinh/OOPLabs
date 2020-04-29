using System;
using System.Collections.Generic;
using System.Text;

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
                if (a < 1) throw new Exception("Natural logarithm error");
                res = Math.Log(a);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return res;
        }

        private double Divide(double a, double b)
        {
            double res = 0;
            try
            {
                if (b == 0) throw new Exception("Division by zero error");
                res = a / b;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return res;
        }

        public static double operator /(Expression exp, double number)
        {
            double res = 0;

            try
            {
                if (number == 0) throw new Exception("Dividing by zero error");
                res = exp.a / number;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return res;
        }
    }
}
