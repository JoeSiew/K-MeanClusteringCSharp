using System;
using System.Drawing;
using System.Windows.Forms;

namespace kMeanClustering
{
    public partial class frmGraph : Form
    {
        public int k;
        public double[] totalSSE;
        Pen pen = new Pen(Color.Black, 1);
        Font font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
        Font myFont = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
        Brush brush = (Brush)Brushes.Black;
        public frmGraph(double[] x, int k)
        {
            totalSSE = (double[])x.Clone();
            InitializeComponent();
            this.k = k;
        }

        private void GraphPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("Sum of Square Errors", font, brush, 10, 25);
            e.Graphics.DrawString("Number of Clusters, K", font, brush, 280, 525);
            e.Graphics.DrawLine(pen, 50, 480, 650, 480); // x-axis
            e.Graphics.DrawLine(pen, 50, 50, 50, 480); // y-axis
            e.Graphics.DrawLine(new Pen(Color.Red, 1), (k + 1) * 100, 
                Convert.ToInt32(520 - totalSSE[k] / 100), (k + 1) * 100, 480);
            
            e.Graphics.DrawString("1", myFont, brush, 95, 490);
            e.Graphics.DrawString("2", myFont, brush, 195, 490);
            e.Graphics.DrawString("3", myFont, brush, 295, 490);
            e.Graphics.DrawString("4", myFont, brush, 395, 490);
            e.Graphics.DrawString("5", myFont, brush, 495, 490);
            e.Graphics.DrawString("6", myFont, brush, 595, 490);

            Point[] points =
            {
                /*
                 new Point(100, Convert.ToInt32(totalSSE[0]/1000)),
                 new Point(200, Convert.ToInt32(totalSSE[1]/1000)),
                 new Point(300, Convert.ToInt32(totalSSE[2]/1000)),
                 new Point(450, Convert.ToInt32(totalSSE[3]/1000)),
                 new Point(500, Convert.ToInt32(totalSSE[4]/1000)),
                 new Point(650, Convert.ToInt32(totalSSE[5]/1000)),
                 */

                 new Point(100, Convert.ToInt32( 520 -   totalSSE[0]/100)),
                 new Point(200, Convert.ToInt32( 520 -   totalSSE[1]/100)),
                 new Point(300, Convert.ToInt32( 520 -   totalSSE[2]/100)),
                 new Point(400, Convert.ToInt32( 520 -   totalSSE[3]/100)),
                 new Point(500, Convert.ToInt32( 520 -   totalSSE[4]/100)),
                 new Point(600, Convert.ToInt32( 520 -   totalSSE[5]/100)),
             };

            e.Graphics.DrawLines(pen, points);
        }
    }
}
