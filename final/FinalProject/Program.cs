using System;
using System.Collections.Generic;

// Clase base Activity
public abstract class Activity
{
    protected DateTime date;
    protected int durationMinutes;

    public Activity(DateTime date, int durationMinutes)
    {
        this.date = date;
        this.durationMinutes = durationMinutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{date.ToShortDateString()} {GetType().Name} ({durationMinutes} min): " +
               $"Distance: {GetDistance()}, Speed: {GetSpeed()}, Pace: {GetPace()}";
    }
}

// Clase derivada Running
public class Running : Activity
{
    private double distance;

    public Running(DateTime date, int durationMinutes, double distance) 
        : base(date, durationMinutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / (base.durationMinutes / 60);
    }

    public override double GetPace()
    {
        return base.durationMinutes / distance;
    }
}

// Clase derivada Cycling
public class Cycling : Activity
{
    private double distance;

    public Cycling(DateTime date, int durationMinutes, double distance) 
        : base(date, durationMinutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / (base.durationMinutes / 60);
    }

    public override double GetPace()
    {
        return base.durationMinutes / distance;
    }
}

// Clase derivada Swimming
public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int durationMinutes, int laps) 
        : base(date, durationMinutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000.0; // Convertir metros a kilómetros
    }

    public override double GetSpeed()
    {
        return GetDistance() / (base.durationMinutes / 60);
    }

    public override double GetPace()
    {
        return base.durationMinutes / GetDistance();
    }
}

// Clase principal del programa
class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        // Agregar algunas actividades de ejemplo
        activities.Add(new Running(new DateTime(2024, 2, 17), 30, 3.0));
        activities.Add(new Cycling(new DateTime(2024, 2, 18), 45, 15.0));
        activities.Add(new Swimming(new DateTime(2024, 2, 19), 60, 20));

        // Mostrar el resumen de cada actividad
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
