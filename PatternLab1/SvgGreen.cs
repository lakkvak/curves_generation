using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PatternLab2
{
    class SvgGreen:IStyle
    {       
    
        

        StreamWriter sw;
        public SvgGreen(StreamWriter sw)
        {

            this.sw = sw;
        }
        public void drawEl(ref List<IPoint> ls)
        {
            
            sw.WriteLine($"<line x1=\"{(float)ls[ls.Count - 2].X}\" y1=\"{(float)ls[ls.Count - 2].Y}\" x2=\"{(float)ls.Last().X}\" y2=\"{(float)ls.Last().Y}\" stroke=\"green\" stroke-width=\"3\"/> ");


        }
        public void drawEnd(ref List<IPoint> ls)
        {
            sw.WriteLine($"<defs> <marker id = \"arrowhead\" markerWidth = \"{10}\" markerHeight = \"{7}\" refX = \"{0}\" refY = \"{3.5}\" orient = \"auto\">  <polygon points = \"0 0, 10 3.5, 0 7\" fill=\"green\"/> </marker> </defs> ");
            sw.WriteLine($"<line x1=\"{(float)ls[ls.Count - 2].X}\" y1=\"{(float)ls[ls.Count - 2].Y}\" x2=\"{(float)ls.Last().X}\" y2=\"{(float)ls.Last().Y}\" stroke=\"green\" stroke-width=\"3\" marker-end=\"url(#arrowhead)\"/> ");
        }
        public void drawBegin(IPoint point)
        {


            sw.WriteLine($"<circle r=\"{5}\" cx=\"{(float)point.X}\"  cy=\"{(float)point.Y}\" fill=\"green\" />");
            

        }
    }
}

