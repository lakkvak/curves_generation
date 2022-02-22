using System;
using System.Collections.Generic;
using System.Text;

namespace PatternLab2
{
   abstract class Decorator : ICurve
    {
        protected ICurve curve;
        public Decorator(ICurve curve)
        {
            this.curve = curve;
        }

        public virtual IPoint GetPoint(double t)
        {
            return curve.GetPoint(t);
        }


    }
}
