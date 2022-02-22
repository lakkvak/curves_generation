using System;
using System.Collections.Generic;
using System.Text;

namespace PatternLab2
{
    class LengthStop:IStopStrat
    {
        public bool start(double t)
        {
            return t <= 1;
        }
        public bool stop(double i, double t, double length, double l, ref double outt)
        {
            if (i >=t)
            {
                outt = length;
                return true;
            }
            else
                return false;
        }
    }
}
