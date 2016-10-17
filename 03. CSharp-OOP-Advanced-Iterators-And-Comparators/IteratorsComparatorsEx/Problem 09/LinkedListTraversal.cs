using System;
using System.Collections;
using System.Collections.Generic;

public class MyList<T> : IEnumerable<T>
{
    private List<T> list;

    public MyList()
    {
        this.list = new List<T>();
    }

    public int Count => this.list.Count;

    public IEnumerator<T> GetEnumerator()
    {
        return new MyListEnumerator<T>(this.list);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void Add(T element)
    {
        this.list.Add(element);
    }

    public bool Remove(T element)
    {
        if (this.list.Contains(element))
        {
            this.list.Remove(element);
            return true;
        }

        return false;
    }

    public class MyListEnumerator<T> : IEnumerator<T>
    {
        private List<T> list;
        private int currentIndex;

        public MyListEnumerator(List<T> list)
        {
            this.list = list;
            this.Reset();
        }

        public T Current
        {
            get
            {
                return this.list[this.currentIndex];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (this.currentIndex < this.list.Count - 1)
            {
                this.currentIndex++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }
    }
}

public class LinkedListTraversal
{
    public static void Main()
    {
        int numberOfCommands = int.Parse(Console.ReadLine());
        MyList<int> myList = new MyList<int>();

        for (int i = 0; i < numberOfCommands; i++)
        {
            string[] command = Console.ReadLine().Split();

            switch (command[0])
            {
                case "Add":
                    myList.Add(int.Parse(command[1]));
                    break;
                case "Remove":
                    myList.Remove(int.Parse(command[1]));
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine(myList.Count);

        string delim = "";

        foreach (var item in myList)
        {
            Console.Write(delim + item);
            delim = " ";
        }

        Console.WriteLine();
    }
}