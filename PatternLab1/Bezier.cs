using System;
using System.Collections.Generic;
using System.Text;

namespace PatternLab2
{
    class Bezier : ACurve
    {
        IPoint c;
        IPoint d;

        public Bezier(IPoint a, IPoint b, IPoint c, IPoint d) : base(a, b)
        {
            this.c = c;
            this.d = d;
        }
        
        public override IPoint GetPoint(double t)
        {
            IPoint p = new Point(0, 0);
            p.X = Math.Pow(1 - t, 3) * a.X + 3 * t * Math.Pow(1 - t, 2) * c.X + 3 * Math.Pow(t, 2) * (1 - t) * d.X + Math.Pow(t, 3) * b.X;
            p.Y = Math.Pow(1 - t, 3) * a.Y + 3 * t * Math.Pow(1 - t, 2) * c.Y + 3 * Math.Pow(t, 2) * (1 - t) * d.Y + Math.Pow(t, 3) * b.Y;
            points.Add(p);
            return p;
            
        }
    }
}
