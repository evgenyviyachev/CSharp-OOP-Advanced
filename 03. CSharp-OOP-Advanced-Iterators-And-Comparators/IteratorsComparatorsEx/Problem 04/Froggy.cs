using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Lake : IEnumerable<int>
{
    public Lake(List<int> list)
    {
        this.List = list;
    }

    public List<int> List { get; private set; }

    public IEnumerator<int> GetEnumerator()
    {
        return new LakeEnumerator(this.List);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class LakeEnumerator : IEnumerator<int>
    {
        private int currentIndex;
        private int difference = 2;

        public LakeEnumerator(List<int> list)
        {
            this.List = list;
            this.Reset();
        }

        public List<int> List { get; private set; }

        public int Current => this.List[this.currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            this.currentIndex += difference;

            if (this.currentIndex >= this.List.Count)
            {
                if (this.List.Count > 1)
                {
                    if (this.List.Count % 2 == 0)
                    {
                        this.currentIndex = this.List.Count - 1;
                    }
                    else
                    {
                        this.currentIndex = this.List.Count - 2;
                    }

                    this.difference = -2;
                }
                else
                {
                    return false;
                }
            }

            if (this.currentIndex < 0)
            {
                return false;
            }

            return true;
        }

        public void Reset()
        {
            this.currentIndex = -2;
        }
    }
}

public class Froggy
{
    public static void Main()
    {
        List<int> lakeNums = Console.ReadLine()
            .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        Lake lake = new Lake(lakeNums);

        List<int> path = new List<int>();

        foreach (var num in lake)
        {
            path.Add(num);
        }

        Console.WriteLine(string.Join(", ", path));
    }
}