using System;
using System.Collections.Generic;
using System.Linq;

public class Box<T>
    where T : IComparable<T>
{
    //default(T) -> default value of the type specified
    public Box()
        : this(default(T))
    {
    }

    public Box(T item)
    {
        this.Value = item;
    }

    public T Value { get; set; }

    public override string ToString()
    {
        return $"{this.Value.GetType().FullName}: {this.Value}";
    }
}

public class GenericCountMethod
{
    public static void Main()
    {
        List<Box<string>> list = new List<Box<string>>();

        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            Box<string> box = new Box<string>(Console.ReadLine());
            list.Add(box);
        }

        Box<string> compare = new Box<string>(Console.ReadLine());

        Console.WriteLine(Count(list, compare));
    }

    public static int Count<T>(List<Box<T>> list, Box<T> compare)
        where T : IComparable<T>
    {
        int counter = list.Count(b => b.Value.CompareTo(compare.Value) > 0);

        return counter;
    }
}