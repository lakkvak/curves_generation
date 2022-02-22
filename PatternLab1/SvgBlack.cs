using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PatternLab2
{
    class SvgBlack:IStyle
    {
        int count = 1;
       
        StreamWriter sw;
        public SvgBlack( StreamWriter sw)
        {
            
            this.sw = sw;
        }
        public void drawEl(ref List<IPoint> ls)
        {
            if (count % 4 == 0)
            {
                sw.WriteLine($" <line x1=\"{(float)ls[ls.Count - 3].X}\" y1=\"{(float)ls[ls.Count - 3].Y}\" x2=\"{(float)ls.Last().X}\" y2=\"{(float)ls.Last().Y}\" stroke=\"black\" stroke-width=\"4\"/> ");
                count++;
            }
            else
                count++;
            
        }
        public void drawEnd(ref List<IPoint> ls)
        {
            sw.WriteLine($"<rect width=\"{10}\" height=\"{10}\" x=\"{(float)ls.Last().X - 5}\"  y=\"{(float)ls.Last().Y - 5}\" fill=\"black\" />");
        }
        public void drawBegin(IPoint point)
        {
            
                
                sw.WriteLine($"<rect width=\"{10}\" height=\"{10}\" x=\"{(float)point.X}\"  y=\"{(float)point.Y - 5}\" fill=\"black\" />");
                    
            
        }
    }
}
