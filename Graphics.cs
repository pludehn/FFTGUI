//https://www.c-sharpcorner.com/article/gdi-tutorial-for-beginners/
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

//Reference to a Graphics object.

public class Hello:Form
{
    public Hello() => Paint += new PaintEventHandler(F1_paint);
    private void F1_paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.DrawString("Hello C#", new Font("Verdana", 20), new SolidBrush(Color.Tomato), 40, 40);
        g.DrawRectangle(new Pen(Color.Pink, 3), 20, 20, 150, 100);
        g.Dispose();
    }
}
public class Clr : Form
{
    Button b1 = new Button();
    TextBox tb = new TextBox();
    ColorDialog clg = new ColorDialog();

    public Clr()
    {
        b1.Click += new EventHandler(b1_click);
        b1.Text = "Change Text Color";
        tb.Location = new Point(50, 50);
        Controls.Add(b1);
        Controls.Add(tb);
    }
    public void b1_click(object sender, EventArgs e)
    {
        clg.ShowDialog();
        tb.BackColor = clg.Color;
    }
}
public class Fonts : Form
{
    Button b1 = new Button();
    TextBox tb = new TextBox();
    FontDialog flg = new FontDialog();
    public Fonts()
    {
        b1.Click += new EventHandler(b1_click);
        b1.Text = "OK";
        tb.Location = new Point(50, 50);
        Controls.Add(b1);
        Controls.Add(tb);
    }
    public void b1_click(object sender, EventArgs e)
    {
        flg.ShowDialog();
        tb.Font = flg.Font;
    }

}

public class DrawGrph : Form
{
    public DrawGrph()
    {
        Text = "Illustrating DrawXXX() methods";
        Size = new Size(450, 400);
        Paint += new PaintEventHandler(Draw_Graphics);
    }
    public void Draw_Graphics(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Pen penline = new Pen(Color.Red, 5);
        Pen penellipse = new Pen(Color.Blue, 5);
        Pen penpie = new Pen(Color.Tomato, 3);
        Pen penpolygon = new Pen(Color.Maroon, 4);
        /*DashStyle Enumeration values are Dash, DashDot, DashDotDot, Dot, Solid etc */
        penline.DashStyle = DashStyle.Dash;
        g.DrawLine(penline, 50, 50, 100, 200);
        //Draws an ellipse.
        penellipse.DashStyle = DashStyle.DashDotDot;
        g.DrawEllipse(penellipse, 15, 15, 50, 50);
        //Draws a Pie
        penpie.DashStyle = DashStyle.Dot;
        g.DrawPie(penpie, 90, 80, 140, 40, 120, 100);
        //Draws a Polygon
        g.DrawPolygon(penpolygon, new Point[]
        {
            new Point(30,140), new Point(270,250), new Point(110,240), new Point(200,170), new Point(70,350), new Point(50,200), new Point(50,100), new Point(20,50) });
    }

}
public class Solidbru : Form
{
    public Solidbru()
    {
        Text = "Using Solid Brushes";
        Paint += new PaintEventHandler(Fill_Graph);
    }
    public void Fill_Graph(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        //Creates a SolidBrush and fills the rectangle
        SolidBrush sb = new SolidBrush(Color.Pink);
        g.FillRectangle(sb, 50, 50, 150, 150);
    }
}
public class Hatchbru:Form
{
    public Hatchbru()
    {
        Text = "Using Solid Brushes";
        Paint += new PaintEventHandler(Fill_Graph);
    }
    public void Fill_Graph(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        //Creates a Hatch Style Brush and fills the rectangle.
        /*Various Hatchstyle Values are DiagonalCross,ForwardDiagonal,Horizontal,Vertical,Solid etc*/
        HatchStyle hs = HatchStyle.Cross;
        HatchBrush sb = new HatchBrush(hs, Color.Blue, Color.Red);
        g.FillRectangle(sb, 50, 50, 150, 150);
    }

}
/* NOT CURRENTLY WORKING
public class Texturedbru : Form
{
    Brush bgbrush;
    Image bgimage;
    public Texturedbru()
    {
        Image bgimage = new Bitmap("dotnet.bmp");
        bgbrush = new TextureBrush(bgimage);
        Paint += new PaintEventHandler(Text_bru);
    }
    public void Text_bru(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.DrawImage(bgimage, 100, 100, 600, 500);
      //  g.FillEllipse(bgbrush, 50, 50, 500, 300);
    }
}
*/
public class Program
{
    static void Main()
    {
         Application.Run(new Hello());
        //Application.Run(new Clr());
        // Application.Run(new Fonts());
        // Application.Run(new DrawGrph());
        //  Application.Run(new Solidbru());
        //Application.Run(new Hatchbru());
       
    }

}



