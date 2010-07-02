using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lissajous
{
    public partial class Lissajous : Form
    {
        public Lissajous()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            float width = (float)(picDrawing.Width - 2), height = (float)(picDrawing.Height - 2);

            double a = readDouble(txtA),
                   d = readDouble(txtD) * Math.PI,
                   b = readDouble(txtB),
                   deltaT = readDouble(txtDeltaT);

            Func<double, float> translateX = x => (float)Math.Round((x + 1.0) * (width - 2) / 2, 0),
                                translateY = y => (float)Math.Round((y + 1.0) * (height - 2) / 2, 2);

            Graphics graphics = picDrawing.CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 1);

            //graphics.DrawRectangle(new Pen(Color.Red, 1), width - 1, height - 1, 1f, 1f);

            double t = 0.0;
            for (int step = 0; step < 20000; step++, t += deltaT)
            {
                double x = Math.Sin(a * t + d),
                       y = Math.Sin(b * t);
                float xx = translateX(x),
                      yy = translateY(y);

                graphics.DrawRectangle(blackPen, xx, yy, 1f, 1f);
            }
        }

        private double readDouble(TextBox textBox)
        {
            double d = 0.0;
            double.TryParse(textBox.Text, out d);

            textBox.Text = d.ToString();

            return d;
        }

        private void picDrawing_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Graphics graphics = picDrawing.CreateGraphics();
            graphics.Clear(Color.White);
        }
    }
}
