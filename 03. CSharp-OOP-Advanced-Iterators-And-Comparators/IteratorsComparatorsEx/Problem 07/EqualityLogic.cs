using System;
using System.Collections.Generic;

public class Person : IComparable<Person>
{
    private readonly string name;
    private readonly int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + name.GetHashCode();
            hash = hash * 23 + age.GetHashCode();
            return hash;
        }
    }
    
    public override bool Equals(object obj)
    {
        if (obj is Person)
        {
            Person otherPerson = obj as Person;
            if (otherPerson.name == this.name
                && otherPerson.age == this.age
                && otherPerson != null)
            {
                return true;
            }
        }

        return false;
    }

    public int CompareTo(Person other)
    {
        if (this.name == other.name)
        {
            return this.age.CompareTo(other.age);
        }
        else
        {
            return this.name.CompareTo(other.name);
        }
    }
}

public class EqualityLogic
{
    public static void Main()
    {
        SortedSet<Person> sorted = new SortedSet<Person>();
        HashSet<Person> hash = new HashSet<Person>();

        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string[] data = Console.ReadLine().Split();

            Person person = new Person(data[0], int.Parse(data[1]));

            sorted.Add(person);
            hash.Add(person);
        }

        Console.WriteLine(sorted.Count);
        Console.WriteLine(hash.Count);
    }
}