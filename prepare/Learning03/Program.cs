using System;
using System.Reflection.Metadata.Ecma335;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    // getters and setters
    public int Numerator
    {
        get { return _numerator; }
        set { _numerator = value; }
    }

    public int Denominator 
    {
        get { return _denominator; }
        set { _denominator = value; }
    }


    // constructors
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int top)
    {
        _numerator = top;
        _denominator = 1;
    }

    public Fraction(int top, int bottom)
    {
        _numerator = top;
        _denominator = bottom;
    }

    public string GetFractionString()
    {
        return $"{Numerator}/{Denominator}";
    }

    public float GetDecimalValue()
    {
        return (float)Numerator / (float)Denominator;
    }

    public void Display()
    {
        Console.WriteLine(GetFractionString());
        Console.WriteLine(GetDecimalValue());
    }
 
}

public class Program
{
    public static void Main(string[] args)
    {
        Fraction fraction = new Fraction(3,4);
        fraction.Display();
    }
    
}

