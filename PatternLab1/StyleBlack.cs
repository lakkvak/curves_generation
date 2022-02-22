using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PatternLab2
{
    class StyleBlack : IStyle
    {
        
        int count = 1;
        IDrawer dr;

        public StyleBlack(IDrawer dr)
        {
            this.dr = dr;
        }
        public void drawBegin( IPoint point)
        {
            dr.DrawRect("black", (float)point.X, (float)point.Y - 5, 10, 10);

            
        }
        public void drawEnd( ref List<IPoint> ls)
        {

            dr.DrawRect("black", (float)ls.Last().X-5, (float)ls.Last().Y - 5, 10, 10);
        }
        public void drawEl( ref List<IPoint> ls)
        {
            if (count % 4 == 0)
            {
                dr.DrawLine("black", (float)ls[ls.Count - 3].X, (float)ls[ls.Count - 3].Y, (float)ls.Last().X, (float)ls.Last().Y,(float) 4);
                count++;
            }
            else
                count++;
        }
    }
}
