using System;
using System.Collections.Generic;
using System.Text;

namespace PatternLab2
{
    interface IStopStrat
    {
         bool start(double t);
         bool stop(double i, double t, double length, double l, ref double outt);
    }
}
