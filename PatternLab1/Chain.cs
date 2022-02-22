using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PatternLab2
{
    class Chain : ICurve
    {
        Tuple<ICurve, ICurve> lines;
        public IPoint GetPoint(double t)
        {
            if (t <= 0.5)
                return lines.Item1.GetPoint(t*2);
            else
                return lines.Item2.GetPoint((t-0.5)*2);
            
            
        }
        public void Join(ICurve curve1,ICurve curve2)
        {
            lines=new Tuple<ICurve, ICurve>(curve1, new MoveTo(curve2, curve1.GetPoint(1)));
                        

        }
        
    }
}
