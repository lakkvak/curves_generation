using System;
using System.Collections.Generic;
using System.Text;

namespace PatternLab2
{
     class MoveTo:Decorator
    {
        IPoint newPoint;
        public MoveTo(ICurve curve, IPoint p) : base(curve)
        {

            newPoint = p;
        }
        public override IPoint GetPoint(double t)
        {
            
            IPoint start = curve.GetPoint(0);
            double xDiff=Math.Abs(newPoint.X - start.X);
            
            if (start.X > newPoint.X)
                xDiff = -xDiff;

            double yDiff = Math.Abs(newPoint.Y - start.Y);
            if (start.Y > newPoint.Y)
                yDiff = -yDiff;

            IPoint p = curve.GetPoint(t);
            return new Point(p.X + xDiff, p.Y + yDiff);
        }
    }
}
