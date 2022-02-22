using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace PatternLab2
{
    class FormDraw : IDrawer
    {
        Graphics gr;
        public FormDraw(Graphics gr)
        {
            this.gr = gr;   
        }
        public void DrawArrow(string color, float x1, float y1, float x2, float y2)
        {
            Brush br = new SolidBrush(Color.FromName(color));
            Pen p = new Pen(br);
            p.EndCap = LineCap.ArrowAnchor;
            p.CustomEndCap = new AdjustableArrowCap(10, 10);
            gr.DrawLine(p,x1,y1,x2,y2);
        }
    

        public void DrawEllipse(string color, float x, float y, float width, float height)
        {
            Brush br = new SolidBrush(Color.FromName(color));
            gr.FillEllipse(br, x, y,width,height);

        }

        public void DrawLine(string color, float x1, float y1, float x2, float y2, float width)
        {
            Brush br = new SolidBrush(Color.FromName(color));

            gr.DrawLine(new Pen(br, width), x1, y1, x2, y2);

        }

        public void DrawRect(string color, float x, float y, float width, float height)
        {
            Brush br = new SolidBrush(Color.FromName(color));
            gr.FillRectangle(br, x, y, width, height);
        }
    }
}
