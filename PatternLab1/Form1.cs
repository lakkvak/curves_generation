using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternLab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Graphics grStyle1;
        Graphics grStyle2;
        List<VisualCurve> vc1;
        List<VisualCurve> vc2;
        bool checkPicBox = false;
        private void Form1_Load(object sender, EventArgs e)
        {
           
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);

            grStyle1 = Graphics.FromImage(pictureBox1.Image);
            grStyle2 = Graphics.FromImage(pictureBox2.Image);
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private List<double> GetRandList()
        {
            var rnd = new Random();

            var tmp =new List<double>();
            for (int i = 0; i < 12; i++)
            {
                tmp.Add(rnd.Next(10, pictureBox1.Height));
            }
            return tmp;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            grStyle1.Clear(Color.White);
            grStyle2.Clear(Color.White);


           
            vc1 = new List<VisualCurve>();
            vc2= new List<VisualCurve>();
            for (int j = 0; j < 1; j++) {
              var  randPoint = GetRandList();

                vc1.Add(new VisualCurve( new Line(new Point(randPoint[0], randPoint[1]), new Point(randPoint[2], randPoint[3]))));
                vc1.Add(new VisualCurve( new Bezier( new Point(randPoint[4], randPoint[5]), new Point(randPoint[6], randPoint[7]), new Point(randPoint[8], randPoint[9]), new Point(randPoint[10], randPoint[11]))));
                randPoint = GetRandList();

                vc2.Add(new VisualCurve(new Line(new Point(randPoint[0], randPoint[1]), new Point(randPoint[2], randPoint[3]))));
                vc2.Add(new VisualCurve(new Bezier(new Point(randPoint[4], randPoint[5]), new Point(randPoint[6], randPoint[7]), new Point(randPoint[8], randPoint[9]), new Point(randPoint[10], randPoint[11]))));

                randPoint.Clear();
            }

           


            Refresh();
            pictureBox1.Refresh();
            pictureBox2.Refresh();
        }

       

        private void label2_Click(object sender, EventArgs e)
        {

        }
        void saveF(PictureBox pb)
        {
            
            if (pb.Image != null)
            {
               SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                string filename = saveFileDialog.FileName;
                using (StreamWriter sw = new StreamWriter(filename, true))
                {
                    sw.WriteLine("<svg  xmlns=\"http://www.w3.org/2000/svg\">");
                    if (checkPicBox)
                        foreach (var element in vc1)
                            element.Draw(new StyleGreen(new SVG(sw)));

                    else
                        foreach (var element in vc2)
                            element.Draw(new StyleBlack(new SVG(sw)));


                    sw.WriteLine("</svg>");

                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            checkPicBox = true;
            saveF(pictureBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkPicBox = false;
            saveF(pictureBox2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            grStyle1.Clear(Color.White);
            grStyle2.Clear(Color.White);
            foreach (var item in vc1)
            {
                
                var tempV = new FragmentDec(item, 1, 0);
                var vis = new VisualCurve(tempV);
                vis.Draw(new StyleGreen(new FormDraw(grStyle1)));
            }
            foreach (var item in vc2)
            {
                var tempV = new FragmentDec(item, 1, 0);
                var vis = new VisualCurve(tempV);
                vis.Draw(new StyleBlack(new FormDraw(grStyle2)));
            }
            pictureBox1.Refresh();
            pictureBox2.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
               
        }
        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
                IPoint p = new Point(e.X, e.Y);
               
                var tmp = new MoveTo(vc1.Last(), p);
                vc1[1] = new VisualCurve(tmp);
                //var vis = new VisualCurve(tmp);
                //vis.Draw(new StyleGreen(new FormDraw(grStyle1)));
                pictureBox1.Refresh();
           

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            var generalPoint = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
           
            var unionFrag1 = new MoveTo(new FragmentDec(vc1.Last(), 0.3, 0.8), generalPoint);
            var unionFrag2 = new MoveTo(new FragmentDec(vc2.Last(), 0.3, 0.8), generalPoint);
            var visual = new VisualCurve(unionFrag1);
            visual.Draw(new StyleGreen(new FormDraw(grStyle1)));
            visual = new VisualCurve(unionFrag2);
            visual.Draw(new StyleBlack(new FormDraw(grStyle1)));
            pictureBox1.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var ch = new Chain();
            var ch1 = new Chain();
            ch.Join(vc2.Last(), vc1.Last());
            ch1.Join(ch, vc1[0]);
            var visual = new VisualCurve(ch1);
            visual.Draw(new StyleGreen(new FormDraw(grStyle2)));
            
            pictureBox2.Refresh();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (vc1 != null) 
                foreach (var element in vc1)
                {
                    element.Draw(new StyleGreen(new FormDraw(grStyle1)));
                }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (vc2 != null) 
                foreach (var element in vc2)
                {
                    element.Draw(new StyleBlack(new FormDraw(grStyle2)));
                }
        }
    }
}
