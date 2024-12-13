using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_17
{
    public partial class Form1 : Form
    {
        Region region1;
        Region region2;
        SolidBrush solid_gray_pen = new SolidBrush(Color.Gray);
        Point point_x = new Point(275, 160);
        Point point_y = new Point(130, 25);
        bool draggingX = false;
        bool draggingY = false;
        Point offset;
        double T = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black,3);
            SolidBrush solid_pen = new SolidBrush(Color.Black);

            // Закрашивание области 1
            GraphicsPath leftBottomCircle1 = new GraphicsPath();
            GraphicsPath leftBottomCircle2 = new GraphicsPath();
            leftBottomCircle1.AddEllipse(150, 150, 100, 100);
            leftBottomCircle2.AddEllipse(100, 100, 100, 100);
            Region regionCircle_1 = new Region(leftBottomCircle1);
            Region regionCircle_2 = new Region(leftBottomCircle2);
            regionCircle_1.Intersect(regionCircle_2);
            g.FillRegion(solid_gray_pen, regionCircle_1);
            region1 = regionCircle_1;

            // Закрашивание области 2
            Rectangle rect = new Rectangle(50, 50, 200, 200);
            GraphicsPath pie = new GraphicsPath();
            GraphicsPath circle = new GraphicsPath();
            GraphicsPath circle2 = new GraphicsPath();
            pie.AddPie(rect, 90, 45);
            circle.AddEllipse(100, 100, 100, 100);
            circle.AddEllipse(50, 50, 200, 200);
            circle2.AddEllipse(50, 150, 100, 100);
            Region regionPie = new Region(pie);
            Region regionCircle = new Region(circle);
            Region regionCircle2 = new Region(circle2);
            regionPie.Intersect(regionCircle);
            regionPie.Intersect(regionCircle2);
            g.FillRegion(solid_gray_pen, regionPie);
            region2 = regionPie;


            // Рисование линий X, Y и Диагональ
            pen.DashStyle = DashStyle.Solid;
            g.DrawLine(pen, 25, 150, 275, 150);
            g.DrawLine(pen, 150, 25, 150, 275);
            g.DrawLine(pen, 50, 250, 250, 50);

            // Рисование стрелочек на X и Y
            Point point1 = new Point(275, 145);
            Point point2 = new Point(275, 155);
            Point point3 = new Point(285, 150);
            Point[] massivPoints = { point1, point2, point3 };
            g.FillPolygon(solid_pen, massivPoints);
            Point point4 = new Point(145, 25);
            Point point5 = new Point(155, 25);
            Point point6 = new Point(150, 15);
            Point[] massivPoints2 = { point4, point5, point6 };
            g.FillPolygon(solid_pen, massivPoints2);

            // Рисование кругов говна
            pen.DashStyle = DashStyle.Solid;
            g.DrawEllipse(pen, 50, 50, 200, 200);
            g.DrawEllipse(pen, 100, 100, 100, 100);
            g.DrawEllipse(pen, 50, 150, 100, 100);
            g.DrawEllipse(pen, 150, 150, 100, 100);

            // Рисование пунктирных линий
            pen.DashStyle = DashStyle.Dash;
            g.DrawLine(pen, 150, 50, 250, 50);
            g.DrawLine(pen, 250, 50, 250, 150);

            // Рисование текста X и Y
            String string_x = "X";
            String string_y = "Y";
            Font font = new Font("Times New Roman", 14);
            g.DrawString(string_x, font, solid_pen, point_x);
            g.DrawString(string_y, font, solid_pen, point_y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Text = region1.IsVisible(e.Location).ToString() + " " + region2.IsVisible(e.Location).ToString();
            }
            catch { }

            if (region1.IsVisible(e.Location) == true)
            {
                solid_gray_pen = new SolidBrush(Color.Red);
                Invalidate(region1);
            }
            else if (region2.IsVisible(e.Location) == true)
            {
                solid_gray_pen = new SolidBrush(Color.Green);
                Invalidate(region2);
            }

            if (draggingX == true)
            {
                point_x = new Point(e.X - offset.X, e.Y - offset.Y);
                Invalidate();
            }
            else if (draggingY == true)
            {
                point_y = new Point(e.X - offset.X, e.Y - offset.Y);
                Invalidate();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Size textSize = TextRenderer.MeasureText("X", new Font("Times New Roman", 14));
            Rectangle rectX = new Rectangle(point_x, textSize);
            Rectangle rectY = new Rectangle(point_y, textSize);

            if (rectX.Contains(e.Location))
            {
                draggingX = true;
                offset = new Point(e.X - point_x.X, e.Y - point_x.Y);
            }
            else if (rectY.Contains(e.Location))
            {
                draggingY = true;
                offset = new Point(e.X - point_y.X, e.Y - point_y.Y);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            draggingX = false;
            draggingY = false;
        }

        private void btnChooseColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                solid_gray_pen.Color = dlg.Color;
                Invalidate();
            }
        }

        private void btnOnAnim_Click(object sender, EventArgs e)
        {
            MainTimer.Start();
        }

        private void btnOffAnim_Click(object sender, EventArgs e)
        {
            point_x = new Point(275, 160);
            Invalidate();
            MainTimer.Stop();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            T += 0.5;
            point_x.X = (int)(275 + 20 * Math.Sin(T));
            point_x.Y = (int)(160 + 20 * Math.Cos(T));
            point_y.X = (int)(130 + 20 * Math.Sin(T));
            point_y.Y = (int)(25 + 20 * Math.Cos(T));
            Invalidate();
        }
    }
}
