using System;
using System.Collections.Generic;
using System.Linq;

public class Data<T>
    where T : IComparable<T>
{
    private List<T> values;

    public Data()
    {
        this.values = new List<T>();
    }

    public void Add(T item)
    {
        if (item != null)
        {
            this.values.Add(item);
        }
    }

    public void Remove(int index)
    {
        if (index < this.values.Count)
        {
            this.values.RemoveAt(index);
        }
    }

    public bool Contains(T item)
    {
        return this.values.Contains(item);
    }

    public void Swap(int index1, int index2)
    {
        if (index1 < this.values.Count && index2 < this.values.Count)
        {
            T temp1 = this.values[index1];
            T temp2 = this.values[index2];
            this.values[index1] = temp2;
            this.values[index2] = temp1;
        }
    }

    public int CountGreaterThan(T item)
    {
        int counter = 0;

        foreach (var element in this.values)
        {
            if (element.CompareTo(item) > 0)
            {
                counter++;
            }
        }

        return counter;
    }

    public T Max()
    {
        return this.values.Max();
    }

    public T Min()
    {
        return this.values.Min();
    }

    public void Print()
    {
        foreach (var item in this.values)
        {
            Console.WriteLine(item);
        }
    }

    public void Sort()
    {
        this.values.Sort();
    }
}

public static class Sorter
{
    public static void Sort<T>(Data<T> data)
        where T : IComparable<T>
    {
        data.Sort();
    }
}

public class CustomListSorter
{
    public static void Main()
    {
        string input = Console.ReadLine();
        Data<string> myData = new Data<string>();

        while (input != "END")
        {
            string[] command = input.Split();

            switch (command[0])
            {
                case "Add":
                    myData.Add(command[1]);
                    break;
                case "Remove":
                    myData.Remove(int.Parse(command[1]));
                    break;
                case "Contains":
                    Console.WriteLine(myData.Contains(command[1]).ToString());
                    break;
                case "Swap":
                    myData.Swap(int.Parse(command[1]), int.Parse(command[2]));
                    break;
                case "Greater":
                    Console.WriteLine(myData.CountGreaterThan(command[1]));
                    break;
                case "Max":
                    Console.WriteLine(myData.Max());
                    break;
                case "Min":
                    Console.WriteLine(myData.Min());
                    break;
                case "Print":
                    myData.Print();
                    break;
                case "Sort":
                    myData.Sort();
                    break;
                default:
                    break;
            }

            input = Console.ReadLine();
        }
    }
}