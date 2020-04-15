using System;
using System.Collections.Generic;
using System.Text;

namespace LabOp5Sharp
{
    class Circle:Figure
    {
        double radius;

        public Circle(double r)
        {
            radius = r;
        }

        public override double Area()
        {
            return radius*radius*3.14159;
        }

        public override double Perimeter()
        {
            return 2*radius*3.14159;
        }
    }
}
