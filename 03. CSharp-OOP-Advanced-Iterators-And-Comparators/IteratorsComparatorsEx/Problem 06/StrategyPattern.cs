using System;
using System.Collections.Generic;

public class Person
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; private set; }
    public int Age { get; private set; }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }
}

public class StrategyPattern
{
    public static void Main()
    {
        SortedSet<Person> sortedOne = new SortedSet<Person>(new ComparerOne());
        SortedSet<Person> sortedTwo = new SortedSet<Person>(new ComparerTwo());

        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string[] data = Console.ReadLine().Split();
            Person person = new Person(data[0], int.Parse(data[1]));
            sortedOne.Add(person);
            sortedTwo.Add(person);
        }

        foreach (var person in sortedOne)
        {
            Console.WriteLine(person);
        }
        foreach (var person in sortedTwo)
        {
            Console.WriteLine(person);
        }
    }

    public class ComparerOne : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Name.Length == y.Name.Length)
            {
                return x.Name.Substring(0, 1).ToLower().CompareTo(y.Name.Substring(0, 1).ToLower());
            }
            else
            {
                return x.Name.Length.CompareTo(y.Name.Length);
            }
        }
    }

    public class ComparerTwo : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}