using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;


//assume 64 points for original complex signal.
static class Constants
{
    public const double Pi = 3.14159265358;
}
public class Example
{
    static void Main()
    {
    
        //This represents a signal of 64 samples, assume sample/s.
        int Ss = 64;
        Signal<double> sig = new Signal<double>(Ss);
        Console.WriteLine("Signal SampleSize: {0}", sig.SS);
        Console.WriteLine("Signal Amplitude: {0}", sig.A.GetHashCode());
        sig.Freqs.Add(300);
        sig.Freqs.Add(600);
       
        for (var i = 0; i < sig.Freqs.Count; i++)
        {
            Console.WriteLine("Frequency is {0}", sig.Freqs.ElementAt(i));
        }
        sig.InitializeSine();
    }
}

public class Signal<Double>
{
    public List<double> Freqs;
    public List<double> Output;
    public int SS;
    public int A { get; set; }
    public Signal(int SampleSize) {
        this.SS = SampleSize;   
        this.A = 1;
        this.Freqs= new List<double>();
        this.Output = new List<double>();
    }
    public List<double> InitializeSine()
    {   //do math and pray.   
        double value = 0;
        for (int i = 1; i < SS; i++)
        {
            for (int j = 0; j < Freqs.Count; j++)
            {
               value = value +  A * Math.Sin((2 * Constants.Pi * Freqs.ElementAt(j) * i) / 180);
               
            }
            Console.WriteLine("Value is {0} at time {1}", value, i);
            Output.Add(value);
        }
        return Output;
    }
    
    
    
  
}







/*
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


/*
public class ListExtensions : IComparable<List<Complex>>
{
    public static T Max<T, TCompare>(this IEnumerable<T> collection, Func<T, TCompare> func) where TCompare : IComparable<TCompare>
    {
        T maxItem = default(T);
        TCompare maxValue = default(TCompare);
        foreach (var item in collection)
        {
            TCompare temp = func(item);
            if (maxItem == null || temp.CompareTo(maxValue) > 0)
            {
                maxValue = temp;
                maxItem = item;
            }
        }
        return maxItem;
    }
}


    public double mag;
    public double Max(List<Complex> list)
    {
        if (list.Count == 0)
            throw new InvalidOperationException("Empty list!");
        double maxValue = double.MinValue;
        foreach (Complex obj in list)
        {
            if (obj.Magnitude > maxValue)
                maxValue = obj.Magnitude;
            else;
        }
        return maxValue;
    }
   public class ListExtensions : IComparable<List<Complex>> 
       private double mag;
       double Min = double.MinValue;
       public double MagT(Complex obj)
       {
           mag = obj.Magnitude;
           return mag;

       }
       */






