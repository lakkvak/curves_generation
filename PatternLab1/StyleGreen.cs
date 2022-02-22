using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace PatternLab2
{
    class StyleGreen : IStyle
    {
        IDrawer dr;
        public StyleGreen(IDrawer dr)
        {
            this.dr = dr;   
        }
        public void drawBegin( IPoint point)
        {
            dr.DrawEllipse("green", (float)point.X - 10, (float)point.Y - 10,15, 15);


        }
        public void drawEnd( ref List<IPoint> ls)
        {
            dr.DrawArrow("green", (float)ls[ls.Count - 2].X, (float)ls[ls.Count - 2].Y, (float)ls.Last().X, (float)ls.Last().Y);
        }
        public void drawEl( ref List<IPoint> ls)
        {
            dr.DrawLine("green",(float)ls[ls.Count - 2].X, (float)ls[ls.Count - 2].Y,(float)ls.Last().X, (float)ls.Last().Y,3);
        }
    }
}
