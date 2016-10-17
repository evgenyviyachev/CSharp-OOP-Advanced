using System;
using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
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

public class GenericSwapMethod2
{
    public static void Main()
    {
        List<Box<int>> list = new List<Box<int>>();
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
            list.Add(box);
        }

        int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Swap(indexes[0], indexes[1], list);

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

    public static void Swap<T>(int index1, int index2, List<Box<T>> list)
    {
        T temp1 = list[index1].Value;
        T temp2 = list[index2].Value;
        list[index1].Value = temp2;
        list[index2].Value = temp1;
    }
}