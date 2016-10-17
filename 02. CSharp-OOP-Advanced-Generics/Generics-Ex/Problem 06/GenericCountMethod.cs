using System;
using System.Collections.Generic;
using System.Linq;

public class Box<T> : IComparable<T>
{
    public Box(T item)
    {
        this.Value = item;
    }

    public T Value { get; set; }

    public int CompareTo(T other)
    {
        return this.Value.ToString().CompareTo(other.ToString());
    }

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

        Console.WriteLine(Count(list.Select(x => x.Value).ToList(), compare.Value));
    }

    public static int Count<T>(List<T> list, T compare)
        where T : IComparable<T>
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