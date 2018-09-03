using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;



static class Constants
{
    public const double Pi = 3.14159265358;
}
public class Example
{
    static void Main()
    {
    
        //This represents a signal of 64 samples, assume sample/s.
        int Ti = 16;
        Signal<double> sig = new Signal<double>(Ti);
        Console.WriteLine("Signal Sampling Period(pending): {0}", sig.Ti);
        sig.FreqAmp.Add(new Tuple<double, double>(45, 1));
        sig.FreqAmp.Add(new Tuple<double, double>(99, 1.5));
        sig.FreqAmp.Add(new Tuple<double, double>(160, 1));
        Console.WriteLine("Frequency: {0}", sig.FreqAmp[0].Item1);
        Console.WriteLine("Amplitude: {0}", sig.FreqAmp[0].Item2);
        int Fs = 360;
        sig.InitializeSine(Fs);
        for (var i = 0; i < sig.Output.Count; i++)
        {
            Console.WriteLine("Amplitude: {0} at sampled time: {1}", sig.Output.ElementAt(i), i * sig.MaxFreq(sig.FreqAmp)/Fs);
        }

    }
}

public class Signal<Double>
{
    public List<Tuple<double, double>> FreqAmp;
    public List<double> Output;
    public int Ti;
    public int Fs { get; set; }
    public Signal(int Time) {
        Ti = Time;
        Output = new List<double>();
        FreqAmp = new List<Tuple<double, double>>();
    }
    public List<double> InitializeSine(int SamplingFreq)
    {     
        double value = 0;
        Fs = SamplingFreq;
        double Fm = MaxFreq(FreqAmp);
        for (float i = 0; i < Ti; i = i + ((float)Fm / Fs))
        {
            value = 0;
            for (int j = 0; j < FreqAmp.Count; j++)
            {    
                value = value + (FreqAmp[j].Item2) * Math.Sin((2 * Constants.Pi * FreqAmp[j].Item1 * i) / 180);        
            }
            Output.Add(value);
        }
        return Output;
    }

    public double MaxFreq(List<Tuple<double, double>> List)
    {
        double Compare = 0;
        foreach (Tuple<double, double> obj in List)
        {
            if (obj.Item1 > Compare)
                Compare = obj.Item1;

        }
        return Compare;
    }
}

  












/* Example of System.Numerics, complex class.
    List<Complex> points = new List<Complex>();
    points.Add(new Complex(0, 0));
    points.Add(new Complex(2, 0));
    points.Add(new Complex(4, 0));
    points.Add(new Complex(6, 0));
    points.Add(new Complex(8, 0));
    points.Add(new Complex(10, 0));
    points.Add(new Complex(8, 0));
    points.Add(new Complex(6, 0));
    points.Add(new Complex(4, 0));
    points.Add(new Complex(2, 0));
    points.Add(new Complex(0, 0));
    points.Add(new Complex(-2, 0));
    points.Add(new Complex(-4, 0));
    points.Add(new Complex(-6, 0));
    points.Add(new Complex(-8, 0));
    points.Add(new Complex(-10, 0));
    points.Add(new Complex(-8, 0));
    points.Add(new Complex(-6, 0));
    points.Add(new Complex(-4, 0));
    points.Add(new Complex(-2, 0));
    points.Add(new Complex(0, 0));

    Console.WriteLine();
    foreach (Complex data in points)
    {
        Console.WriteLine(data);
    }
    */

    



