using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace halihali
{
    public partial class Form1 : Form
    {
        Bitmap sun = Properties.Resources.sun;
        Bitmap palm = Properties.Resources.palm1;
        Bitmap grass = Properties.Resources.gtrava;
        int x1 = 700, x2 = 300, x3 = 500;
        int y1 = 30, y2 = 120, y3 = 500;
        Bitmap[] helicopter1 = new Bitmap[2] { Properties.Resources._1, Properties.Resources._2, };
        Bitmap[] helicopter2 = new Bitmap[2] { Properties.Resources._3, Properties.Resources._4, };
        Bitmap[] helicopter3 = new Bitmap[2] { Properties.Resources._3, Properties.Resources._4, };
        Bitmap[] boom = new Bitmap[25] { Properties.Resources.V1, Properties.Resources.V2, Properties.Resources.V3, Properties.Resources.V4, Properties.Resources.V5, Properties.Resources.V6,
            Properties.Resources.V7, Properties.Resources.V8, Properties.Resources.V9, Properties.Resources.V10, Properties.Resources.V11, Properties.Resources.V12, Properties.Resources.V13,
            Properties.Resources.V14, Properties.Resources.V15, Properties.Resources.V16, Properties.Resources.V17, Properties.Resources.V18, Properties.Resources.V19, Properties.Resources.V20,
            Properties.Resources.V21, Properties.Resources.V22, Properties.Resources.V23, Properties.Resources.V24, Properties.Resources.V25};
        int index = 0;
        int indboom = 0;
        bool explosion = false;
        int direction;
                     

        public Form1()
        {

            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (direction == 2)
            {
                y3 += 50;
            }
            else
            {
                y3 -= 10;
            }
            if (y3 < 0 - helicopter3[index].Height + 50)
            {
                direction = 2;
            }
             
             if (y3 > this.Height - helicopter3[index].Height - 50)
             {
                  y3 = this.Height - helicopter3[index].Height - 50; 
                  explosion = true;
                  timer2.Start();
             }

            x1 -= 12; x2 += 12;
            if (index == 0)
                index = 1;
            else index = 0;
            if (x1 < 0 - helicopter1[index].Width)
                x1 = this.Width;
            if (x2 > this.Width + helicopter1[index].Width)
                x2 = 0;
            this.Refresh();
        }



        private void timer2_Tick(object sender, EventArgs e)
        {
            if (indboom < 24)
                indboom++;
            else 
            {
                timer2.Stop();
                explosion = false;
            }
            this.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.FromArgb(0, 204, 255));
            g.DrawImage(sun, 0, 0);
            g.DrawImage(palm, this.Width - palm.Width - 100, this.Height - palm.Height - 130);
            for (int i = 0; i < this.Width / grass.Width + 1; i++)
                g.DrawImage(grass, i * grass.Width, this.Height - 70);
            g.DrawImage(helicopter1[index], x1, y1);
            g.DrawImage(helicopter2[index], x2, y2);
            g.DrawImage(helicopter3[index], x3, y3);
            if (explosion)
            {
                g.DrawImage(boom[indboom], x3, y3);
            }
        }
    }
}