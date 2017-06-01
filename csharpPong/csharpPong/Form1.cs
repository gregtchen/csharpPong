using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpPong
{
    public partial class Form1 : Form
    {
        Graphics gfx;
        Bitmap bmp;
        Random rnd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Dock = DockStyle.Fill;
            timer1.Enabled = true;
            rnd = new Random();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gfx = Graphics.FromImage(bmp);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gfx.FillEllipse(new SolidBrush(Color.Purple), 10, 10, 30, 30);

            pictureBox1.Image = bmp;
        }
    }
}
