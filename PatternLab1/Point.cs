using System;
using System.Collections.Generic;
using System.Text;

namespace PatternLab2
{
    class Point: IPoint
    {
        double x;
        double y;
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
    }
}
