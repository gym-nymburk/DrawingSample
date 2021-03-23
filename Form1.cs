using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            setting = new Setting();

            propertyGrid1.SelectedObject = setting;

            Draw(setting);
        }


        private Setting setting;

        private void btnDraw_Click(object sender, EventArgs e)
        {
            Draw(setting);   
        }


        private void DrawCircle(Graphics g, Pen pen, Point center, int radius)
        {
            g.DrawEllipse(pen, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);
        }

        private void Draw(Setting setting)
        {
            Bitmap bmp = new Bitmap(pnlCanvas.Width, pnlCanvas.Height);
            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Pen pen = new Pen(setting.Color, setting.Width);

            Point center = new Point(pnlCanvas.Width / 2, pnlCanvas.Height / 2);

            DrawCircle(g, pen, center, setting.Radius);

            pnlCanvas.BackgroundImage = bmp;

            lblRadius.Text = $"radius: {setting.Radius}";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            setting.Radius = trackBar1.Value;
            Draw(setting);
        }

        private void lblRadius_Click(object sender, EventArgs e)
        {

        }
    }

    public class Setting
    {
        public Color Color { get; set; } = Color.Red;

        public int Width { get; set; } = 2;

        public int Radius { get; set; } = 100;
    }
}
