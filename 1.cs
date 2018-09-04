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
        int Ti = 2; 
        Signal<double> sig = new Signal<double>(Ti);
        Console.WriteLine("Signal Sampling Period(pending): {0}", sig.Ti);
        sig.FreqAmp.Add(new Tuple<double, double, double>(130, 1, 0)); //(Frequency, Amplitude, Shift)
        Console.WriteLine("Frequency: {0}", sig.FreqAmp[0].Item1);
        Console.WriteLine("Amplitude: {0}", sig.FreqAmp[0].Item2);
        sig.Fs = 130;
        sig.Sine(sig.Fs);
        sig.Print();
    }
}

public class Signal<Double>
{
    public List<Tuple<double, double, double>> FreqAmp; //(Frequency, Amplitude, Phase (in degrees))
    public List<double> Output;
    public int Ti {get; set;} 
    public int Fs { get; set; }
    public double phase;
    public Signal(int Time)
    {
        Ti = Time;
        Output = new List<double>();
        FreqAmp = new List<Tuple<double, double, double>>();
    }
    public void Print()
    {
        float t = 0;
        for (int i = 0; i < Output.Count; i++, t = t+ (1/(float)Fs))
        {        
            Console.WriteLine("Amplitude: {0} at {1}s", Output.ElementAt(i), t);
            
        }
        Console.WriteLine("Number of Samples: {0}, at Sampling Frequency {1} Hz", Output.Count(), Fs);
    }
    public double MaxFreq(List<Tuple<double, double, double>> List)
    {
        double Compare = 0;
        foreach (Tuple<double, double, double> obj in List)
        {
            if (obj.Item1 > Compare)
                Compare = obj.Item1;
        }
        return Compare;
    }
    public List<double> Sine(int SamplingFreq)
    {
        Output.Clear();
        double value = 0;
        Fs = SamplingFreq;
        double Fm = MaxFreq(FreqAmp);
        for (float i = 0; i < Ti; i = i + (1 / (float)Fs))
        {
            value = 0;
            for (int j = 0; j < FreqAmp.Count; j++)
            {
                phase = (2 * Constants.Pi * FreqAmp[j].Item3) / 180;
                value = value + (FreqAmp[j].Item2) * Math.Sin(((2 * Constants.Pi * FreqAmp[j].Item1 * i) / 180) - phase);
            }
            Output.Add(value);
        }
        return Output;
    }
    public List<double> Square(int SamplingFreq, int harmonics)
    {
        Output.Clear();
        int Harmonics = harmonics; //How many odd harmonics we use to approximate the square wave.
        double value = 0;
        Fs = SamplingFreq;
        double Fm = MaxFreq(FreqAmp);
        if (Harmonics != 0)
        {
            for (float i = 0; i < Ti; i = i + ( 1/ (float)Fs)) //Time axis
            {
                value = 0;
                for (int j = 1; j <= Harmonics; j++) //Harmonics
                {
                    for (int k = 0; k < FreqAmp.Count; k++)
                    {
                        phase = (2 * Constants.Pi * FreqAmp[k].Item3) / 180;
                        value = value + FreqAmp[k].Item2 * (4 / Constants.Pi) * (Math.Sin(((2 * Constants.Pi * FreqAmp[k].Item1 * i * (2 * j - 1)) / 180) - phase) / (2 * j - 1));
                    }
                }
                Output.Add(value);
            }
        }
        else if (Harmonics == 0)
            throw new DivideByZeroException("Exception thrown: Specify integer for odd harmonics to be considered.");
        return Output;
    }
    public List<double> Triangle(int SamplingFreq, int harmonics)
    {
        Output.Clear();
        int Harmonics = harmonics;
        double value = 0;
        Fs = SamplingFreq;
        double Fm = MaxFreq(FreqAmp);

        for (float i = 0; i < Ti; i = i + (1/ (float)Fs))
        {
            value = 0;
            for (int j = 1; j <= Harmonics; j++)
            {
                for (int k = 0; k < FreqAmp.Count; k++)
                {
                    phase = (2 * Constants.Pi * FreqAmp[k].Item3) / 180;
                    value = value + FreqAmp[k].Item2 * (8 / Constants.Pi * Constants.Pi) * Math.Pow(-1, j + 1) * (Math.Sin(((2 * Constants.Pi * FreqAmp[k].Item1 * i * (2 * j - 1)) / 180) - phase) / ((2 * j - 1) * (2 * j - 1)));
                }
            }
            Output.Add(value);
        }
        return Output;
    }

    public List<double> Sawtooth(int SamplingFreq, int harmonics)
    {
        int Harmonics = harmonics;
        Output.Clear();
        double value = 0;
        Fs = SamplingFreq;
        double Fm = MaxFreq(FreqAmp);
        for (float i = 0; i < Ti; i = i + (1/ (float)Fs))
        {
            value = 0;
            for (int j = 1; j <= Harmonics; j++)
            {
                for (int k = 0; k < FreqAmp.Count; k++)
                {
                    phase = (2 * Constants.Pi * FreqAmp[k].Item3) / 180;
                    value = value + FreqAmp[k].Item2 * (2 / Constants.Pi) * (Math.Sin(((2 * Constants.Pi * FreqAmp[k].Item1 * i) / 180) - phase) / j);
                }
            }
            Output.Add(value);
        }
        return Output;
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

    



