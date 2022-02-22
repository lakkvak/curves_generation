using System;
using System.Collections.Generic;
using System.Text;

namespace PatternLab2
{
    abstract class ACurve : ICurve
    {
        protected IPoint a;
        protected IPoint b;
        protected List<IPoint> points = new List<IPoint>();
       
        public IStopStrat StopStrat { get; set; }
        public ACurve(IPoint a, IPoint b)
        {
            this.a = a;
            this.b = b;
        }
       
        public abstract IPoint GetPoint(double t);
        public double Calculate( double t,IStopStrat stopStrat)
        {
            double length = 0;
            double l = t;
            double outt = 0;
            double i = 0;
            int j = 0;
            if (stopStrat.start(t))
            {
                
                while (i < 1 - 0.02)
                {
                    length += Math.Sqrt(Math.Pow(points[j + 1].X - points[j].X, 2) + Math.Pow(points[j + 1].Y - points[j].Y, 2));
                    j++;
                    i += 0.01;
                    if (stopStrat.stop(i, t - 0.02, length, l, ref outt))
                        return outt;
                }
            }
            return -1;
                
            
            //return  Strategy.calc(points, t);
        }

    }

}
