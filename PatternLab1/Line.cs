using System;
using System.Collections.Generic;
using System.Text;

namespace PatternLab2
{
    class Line : ACurve
    {
        public Line(IPoint a, IPoint b) : base(a, b) { }
       
        public override IPoint GetPoint(double t)
        {
            IPoint p = new Point(0, 0);
            p.X = (1 - t) * a.X + t * b.X;
            p.Y = (1 - t) * a.Y + t * b.Y;
            points.Add(p);
            return p;
        }
    }
}
