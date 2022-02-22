using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PatternLab2
{
    class SVG : IDrawer
    {
        StreamWriter sw;
        public SVG(StreamWriter sw)
        {
            this.sw = sw;
        }
        public void DrawArrow(string color, float x1, float y1, float x2, float y2)
        {

            sw.WriteLine($"<defs> <marker id = \"arrowhead\" markerWidth = \"{10}\" markerHeight = \"{7}\" refX = \"{0}\" refY = \"{3.5}\" orient = \"auto\">  <polygon points = \"0 0, 10 3.5, 0 7\" fill=\"{color}\"/> </marker> </defs> ");
            sw.WriteLine($"<line x1=\"{x1}\" y1=\"{y1}\" x2=\"{x2}\" y2=\"{y2}\" stroke=\"{color}\" stroke-width=\"3\" marker-end=\"url(#arrowhead)\"/> ");
        }
    

       

        public void DrawEllipse(string color, float x, float y, float width, float height)
        {
            sw.WriteLine($"<circle r=\"{width / 2}\" cx=\"{x}\"  cy=\"{y}\" fill=\"{color}\" />");
        }

        public void DrawLine(string color, float x1, float y1, float x2, float y2, float width)
        {
            sw.WriteLine($"<line x1=\"{x1}\" y1=\"{y1}\" x2=\"{x2}\" y2=\"{y2}\" stroke=\"{color}\" stroke-width=\"{width}\"/> ");

        }

        public void DrawRect(string color, float x, float y, float width, float height)
        {
            sw.WriteLine($"<rect width=\"{width}\" height=\"{height}\" x=\"{x}\"  y=\"{y}\" fill=\"{color}\" />");

        }
    }
}
