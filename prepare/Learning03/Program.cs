// Learning03prepareProgram.cs

using System;

class Program
{
    static void Main()
    {
        // Verify that you can run the project.
        Console.WriteLine("Project is running...");

        // Create fractions using the Fraction class.
        Fraction fraction1 = new Fraction();       // 1/1
        Fraction fraction2 = new Fraction(6);     // 6/1
        Fraction fraction3 = new Fraction(6, 7);  // 6/7

        // Display the fractions.
        Console.WriteLine(fraction1.GetFractionString());  // 1/1
        Console.WriteLine(fraction2.GetFractionString());  // 6/1
        Console.WriteLine(fraction3.GetFractionString());  // 6/7

        // Display the decimal values.
        Console.WriteLine(fraction1.GetDecimalValue());  // 1.0
        Console.WriteLine(fraction2.GetDecimalValue());  // 6.0
        Console.WriteLine(fraction3.GetDecimalValue());  // 0.8571428571428571
    }
}

class Fraction
{
    private int _top;
    private int _bottom;

    // Constructors
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getters and setters
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Methods to return representations
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}
