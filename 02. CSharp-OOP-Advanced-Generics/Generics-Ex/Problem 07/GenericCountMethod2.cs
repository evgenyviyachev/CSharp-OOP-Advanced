using System;
using System.Collections.Generic;

public class Box : IComparable<double>
{
    public Box(double item)
    {
        this.Value = item;
    }

    public double Value { get; set; }

    public int CompareTo(double other)
    {
        return this.Value.CompareTo(other);
    }

    public override string ToString()
    {
        return $"{this.Value.GetType().FullName}: {this.Value}";
    }
}

public class GenericCountMethod2
{
    public static void Main()
    {
        List<Box> list = new List<Box>();

        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            Box box = new Box(double.Parse(Console.ReadLine()));
            list.Add(box);
        }

        Box compare = new Box(double.Parse(Console.ReadLine()));

        Console.WriteLine(Count(list, compare.Value));
    }

    public static int Count<T>(List<T> list, double compare)
        where T : IComparable<double>
    {
        int counter = 0;
        
        foreach (var item in list)
        {
            if (item.CompareTo(compare) > 0)
            {
                counter++;
            }
        }

        return counter;
    }
}