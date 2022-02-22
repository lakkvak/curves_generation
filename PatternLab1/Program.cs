using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PatternLab2
{
    
  
    interface ICurve
    {
         IPoint GetPoint(double t);
    }
   
   
    
   
    interface IDrawable
    {
        public  void Draw(IStyle st);
    }
    
    
    
    
    
     class VisualCurve : ICurve, IDrawable
    {
        IStyle st;
        ICurve line;
        public VisualCurve(ICurve curve)
        {
            line = curve;
        }
        public  void Draw(IStyle st)
        {
            var ls = new List<IPoint>();
            this.st = st;
            ls.Add(this.GetPoint(0));
            st.drawBegin(ls.Last());

            for (double i = 0.01; i < 1 - 0.01; i += 0.01)
            {
                ls.Add(this.GetPoint(i));

                st.drawEl(ref ls);
            }
            st.drawEnd(ref ls);

           
        }
        public  IPoint GetPoint(double t)
        {
            return line.GetPoint(t);
        }
     }
    
   
                
                
          
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //line.StopStrat = new LengthStop();
            //double leng = line.Calculate(1);
            //line.StopStrat = new ParamStop();
            //double t = line.Calculate(leng / 2);



            //st.drawBegin(GetPoint(t));
        }
    }
}
