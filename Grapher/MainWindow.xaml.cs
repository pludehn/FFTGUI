﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace Grapher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private Point currentPoint = new Point();
        MouseButtonEventHandler paintSurface;
      //  RoutedEventHandler RoutedEvnt;
        public MainWindow()
        {
            InitializeComponent();


          //  Main = new Canvas();
            //Main.Loaded += new RoutedEventHandler(Draw_Graphics);
        }
        private void Draw_Graphics(object sender, RoutedEventArgs e)
        {
            const double margin = 30;
            double xmin = margin;
            // PropertyMetadata pmXMAX = Grapher.MainWindow.WidthProperty.DefaultMetadata;
            // (double)pmXMAX.DefaultValue;
            double xmax = Main.Width - margin;
            double ymin = margin;
            //PropertyMetadata pmYMAX = Grapher.MainWindow.WidthProperty.DefaultMetadata;
            //double ymax = (double)pmYMAX.DefaultValue;
            double ymax = Main.Height - margin;
            const double step = 20;
            //X-Axis
            GeometryGroup xaxis_geom = new GeometryGroup();
            xaxis_geom.Children.Add(new LineGeometry(new Point(0, ymax), new Point(Main.Width, ymax)));
            for (double x = xmin + step; x <= Main.Width - step; x += step)
            {
                xaxis_geom.Children.Add(new LineGeometry(new Point(x, ymax - margin / 2), new Point(x, ymax + margin / 2)));
            }
            Path xaxis_path = new Path
            {
                StrokeThickness = 25,
                Stroke = Brushes.Black,
                Data = xaxis_geom
            };
            Main.Children.Add(xaxis_path);

            //Y-Axis
            GeometryGroup yaxis_geom = new GeometryGroup();
            yaxis_geom.Children.Add(new LineGeometry(new Point(xmin, 0), new Point(xmin, Main.Height)));
            for (double y = step; y <= Main.Height - step; y += step)
            {
                yaxis_geom.Children.Add(new LineGeometry(new Point(xmin - margin / 2, y), new Point(xmin + margin / 2, y)));
            }
            Path yaxis_path = new Path
            {
                StrokeThickness = 25,
                Stroke = Brushes.Black,
                Data = yaxis_geom
            };
            Main.Children.Add(yaxis_path);
        }
        private void Canvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);
        }
        private void Canvas_MouseMove_1(object sender,MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line();
                line.Stroke = SystemColors.WindowFrameBrush;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;
                currentPoint = e.GetPosition(this);
                Main.Children.Add(line);
            }
        }
    }
}

/*
public class Program
{
    static void Main()
    {
        Grapher.MainWindow main = new Grapher.MainWindow();
    }

}
*/
/*
 * 
static class Constants
{
    public const double PI = 3.141592653582795;
}

public class SineWave:Window
{
    public int Ti { get; set; }
    public double F { get; set; }
    public double A { get; set; }
    public int Fs { get; set; }
    public Point[] arr;
    public double u = 0;
    public List<double> data;
    public double phase;
    private RoutedEventHandler RoutedEvnt;

    public SineWave()
    {
     
      //  List<double> data = new List<double>();
      //  data = GenerateSineWave();
      //  arr = LoadData(data);
        RoutedEvnt += new RoutedEventHandler(Draw_Graphics);
    }
    public List<double> GenerateSineWave()
    {
        double value = 0;
        phase = (2 * Constants.PI * phase) / 180;
        for (float i = 0; i < Ti; i = i + (1 / (float)Fs))
        {
            value = (A * (double)Math.Sin((2 * Constants.PI * F * i / 180) - phase));
            data.Add(value);
        }
        return data;
    }
    public Point[] LoadData(List<double> IN)
    {
        data = IN;
        int size = data.Count;
        arr = new Point[size];
        for (int i = 0; i < size; i++, u = u + (1 / (float)Fs))
        {
            arr[i] = new Point(u, data.ElementAt(i));
        }
        return arr;
    }
    private void Draw_Graphics(object sender, RoutedEventArgs e)
    {
        const double margin = 10;
        double xmin = margin;
        PropertyMetadata pmXMAX = Grapher.MainWindow.WidthProperty.DefaultMetadata;
        double xmax = (double)pmXMAX.DefaultValue;
        double ymin = margin;
        PropertyMetadata pmYMAX = Grapher.MainWindow.WidthProperty.DefaultMetadata;
        double ymax = (double)pmYMAX.DefaultValue;
        const double step = 10;

        //X-Axis
        GeometryGroup xaxis_geom = new GeometryGroup();
        xaxis_geom.Children.Add(new LineGeometry(new Point(0, ymax), new Point(Width, ymax)));
        for (double x = xmin + step; x <= Width - step; x += step)
        {
            xaxis_geom.Children.Add(new LineGeometry(new Point(x, ymax - margin / 2), new Point(x, ymax + margin / 2)));
        }
        Path xaxis_path = new Path();
        xaxis_path.StrokeThickness = 1;
        xaxis_path.Stroke = Brushes.Black;
        xaxis_path.Data = xaxis_geom;
        AddChild(xaxis_path);

        //Y-Axis
        GeometryGroup yaxis_geom = new GeometryGroup();
        yaxis_geom.Children.Add(new LineGeometry(new Point(xmin, 0), new Point(xmin, Height)));
        for (double y = step; y <= Height - step; y += step)
        {
            yaxis_geom.Children.Add(new LineGeometry(new Point(xmin - margin / 2, y), new Point(xmin + margin / 2, y)));
        }
        Path yaxis_path = new Path();
        yaxis_path.StrokeThickness = 1;
        yaxis_path.Stroke = Brushes.Black;
        yaxis_path.Data = yaxis_geom;
        AddChild(yaxis_path);
    }
}
*/