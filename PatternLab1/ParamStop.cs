using System;
using System.Collections.Generic;
using System.Text;

namespace PatternLab2
{
    class ParamStop:IStopStrat
    {
        public bool start(double t)
        {
            return true;
        }
        public bool stop(double i, double t, double length, double l, ref double outt)
        {
            double temp = Math.Round(length, 10) - Math.Round(l, 10);
            if (temp>=0 && temp<5)
            {
                outt = i;
                return true;
            }
            else
                return false;
        }
    }
}
