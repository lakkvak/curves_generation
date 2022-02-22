using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PatternLab2
{
    interface IStyle
    {
        public void drawEl( ref List<IPoint> ls);
        public void drawEnd( ref List<IPoint> ls);
        public void drawBegin( IPoint point);
    }
}
