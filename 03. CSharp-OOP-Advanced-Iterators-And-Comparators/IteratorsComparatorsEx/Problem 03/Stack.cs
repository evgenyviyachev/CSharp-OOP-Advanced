using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Stack : IEnumerable<int>
{
    public Stack()
    {
        this.List = new List<int>();
    }

    public List<int> List { get; private set; }

    public void Push(List<int> elementsToPush)
    {
        for (int i = 0; i < elementsToPush.Count; i++)
        {
            this.List.Add(elementsToPush[i]);
        }
    }

    public void Pop()
    {
        if (this.List.Count == 0)
        {
            Console.WriteLine("No elements");
        }
        else
        {
            this.List.RemoveAt(this.List.Count - 1);
        }
    }

    public IEnumerator<int> GetEnumerator()
    {
        return new StackEnumerator(this.List);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class StackEnumerator : IEnumerator<int>
    {
        private int currentIndex;

        public StackEnumerator(List<int> list)
        {
            this.ListInts = list;
            this.Reset();
        }

        public List<int> ListInts { get; private set; }

        public int Current => this.ListInts[this.currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (this.currentIndex > 0)
            {                
                this.currentIndex--;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            this.currentIndex = this.ListInts.Count;
        }
    }
}

public class StackProblem
{
    public static void Main()
    {
        string input = Console.ReadLine();
        Stack stack = new Stack();

        while (input != "END")
        {
            List<string> data = input.Split(new[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim(',')).ToList();

            if (data.Count == 1)
            {
                stack.Pop();
            }
            else
            {
                stack.Push(data.GetRange(1, data.Count - 1).Select(int.Parse).ToList());
            }

            input = Console.ReadLine();
        }

        for (int i = 0; i < 2; i++)
        {
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }        
    }
}