using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T> : IEnumerable<T>
{
    private int currentIndex;

    public ListyIterator(List<T> list)
    {
        this.List = list;
        this.Reset();
    }

    public List<T> List { get; private set; }

    public void Reset()
    {
        this.currentIndex = 0;
    }

    public bool Move()
    {
        if (this.currentIndex < this.List.Count - 1)
        {
            this.currentIndex++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool HasNext()
    {
        return this.currentIndex < this.List.Count - 1;
    }

    public void Print()
    {
        if (this.List.Count == 0)
        {
            Console.WriteLine("Invalid Operation!");
        }
        else
        {
            Console.WriteLine(this.List[currentIndex]);
        }
    }

    public void PrintAll()
    {
        Console.WriteLine(string.Join(" ", this.List));
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.List.Count; i++)
        {
            yield return this.List[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

public class Collection
{
    public static void Main()
    {
        List<string> createCommand = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        ListyIterator<string> list = new ListyIterator<string>(createCommand.GetRange(1, createCommand.Count - 1));

        string input = Console.ReadLine();

        while (input != "END")
        {
            switch (input)
            {
                case "Move":
                    Console.WriteLine(list.Move());
                    break;
                case "HasNext":
                    Console.WriteLine(list.HasNext());
                    break;
                case "Print":
                    list.Print();
                    break;
                case "PrintAll":
                    list.PrintAll();
                    break;
                default:
                    break;
            }
            input = Console.ReadLine();
        }
    }
}