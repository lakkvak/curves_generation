using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PatternLab2
{
     interface IDrawer
    {
        void DrawEllipse(string color,float x,float y,float width,float height );
        void DrawArrow(string color, float x1, float y1, float x2, float y2);
    
        void DrawLine(string color, float x1, float y1, float x2,float y2, float width);
        void DrawRect(string color, float x, float y, float width, float height);
    }
}
