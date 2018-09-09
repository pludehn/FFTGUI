using System;
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
using System.Diagnostics;

namespace SignalGrapher
{
    static class Constants
    {
        public const double PI = 3.141592653839793268533832795;
    }

    public partial class MainWindow : Window
    {
        private TextBox xy = new TextBox();
        private Point currentPoint = new Point();
        private double Fs { get; set; }
        private double Ti;
        private double Freq { get; set; }
        private double A { get; set; }
        private int Harmonics { get; set; }
        Polyline apoly = new Polyline();
        PointCollection Function = new PointCollection();
        Point GetMousePos()
        {
            return Grid.PointToScreen(Mouse.GetPosition(Grid));
        }
        public MainWindow()
        {
            InitializeComponent();
            xy.Background = Brushes.Transparent;
            xy.TextWrapping = TextWrapping.Wrap;
            Freq = 60;
            A = 1;
            Fs = 120;
            Controls.DataContext = this;
            if (apoly.IsMouseOver == true)
            {
                Grid.Children.Add(xy);
                xy.Text = GetMousePos().ToString();
                Canvas.SetLeft(xy, GetMousePos().X);
                Canvas.SetTop(xy, GetMousePos().Y);
            }
            
        }
        //Code to calculate data/fit curve
        private void LoadedData(object sender, RoutedEventArgs e)
        {
            CalculateData();
        }
        private void CalculateData()
        {
            Grid.Children.Remove(apoly);
            Function.Clear();
            double step = 1 / Fs;
            double width = Grid.ColumnDefinitions[0].ActualWidth;
            double height = Grid.RowDefinitions[0].ActualHeight;
            double SX =  8*width* (1 / Fs); 
            double SY = (height*A / 4);
            Ti = (4*width) / SX;
           // PointCollection Function = new PointCollection();
            for (double i = 0; i < Ti; i = i + step)
            {
                Point cord = new Point();
                cord.X = i * SX;
                cord.Y = 225 - (SY * Math.Sin((2 * Constants.PI * Freq * i)/180));
                Function.Add(cord);
            }
            //Polyline apoly = new Polyline();
            apoly.Stroke = System.Windows.Media.Brushes.Green;
            apoly.StrokeThickness = 2;
            apoly.Points = Function;
            Grid.Children.Add(apoly);
            Grid.SetColumnSpan(apoly, 4);
            Grid.SetRowSpan(apoly, 2);
            TextFreq.Text = Freq.ToString();
            TextAmp.Text = A.ToString();
            TextFs.Text = Fs.ToString();
        }        
        private void KeyDown_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && sender == TextFreq)
            {
             this.Freq = Double.Parse(TextFreq.Text);
             CalculateData();
            }
            else if (e.Key == Key.Return && sender == TextAmp)
            {
                this.A = Double.Parse(TextAmp.Text);
                CalculateData();
            }
            else if (e.Key == Key.Return && sender == TextFs)
            {
                this.Fs = Double.Parse(TextFs.Text);
                CalculateData();
            }
            else if (e.Key == Key.Return && sender == TextHar)
            {
                this.Harmonics = int.Parse(TextHar.Text);
                CalculateData();
            }
        }
        //Code to inspect visual elements
        private void MouseOver(object sender, MouseEventArgs e)
        {
            
        }
    }
}
