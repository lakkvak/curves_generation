using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternLab2
{
    class FragmentDec : Decorator
    {
        double t_start;
        double t_finish;
        public FragmentDec(ICurve curve,double t_start,double t_finish) : base(curve)
        {
         
            this.t_start = t_start;
           this.t_finish = t_finish;
           
                
        }
        public override IPoint GetPoint(double t)
        {
           
            return curve.GetPoint((t_finish - t_start) * t + t_start);

        }

    }
}
