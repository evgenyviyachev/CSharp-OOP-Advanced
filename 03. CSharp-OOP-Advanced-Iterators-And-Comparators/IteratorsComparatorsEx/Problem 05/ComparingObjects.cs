using System;
using System.Collections.Generic;

public class Person : IComparable<Person>
{
    public Person(string name, int age, string town)
    {
        this.Name = name;
        this.Age = age;
        this.Town = town;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Town { get; set; }

    public int CompareTo(Person other)
    {
        if (this.Name == other.Name)
        {
            if (this.Age == other.Age)
            {
                return this.Town.CompareTo(other.Town);
            }
            else
            {
                return this.Age.CompareTo(other.Age);
            }
        }
        else
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}

public class ComparingObjects
{
    public static void Main()
    {
        List<Person> people = new List<Person>();

        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] data = input.Split();

            Person person = new Person(data[0], int.Parse(data[1]), data[2]);
            people.Add(person);

            input = Console.ReadLine();
        }

        int numberOfPersonToCompareWith = int.Parse(Console.ReadLine()) - 1;

        int matches = 0;

        Person personToCompareWith = people[numberOfPersonToCompareWith];

        for (int i = 0; i < people.Count; i++)
        {
            if (i == numberOfPersonToCompareWith)
            {
                continue;
            }
            if (people[i].CompareTo(personToCompareWith) == 0)
            {
                matches++;
            }
        }

        if (matches == 0)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            matches++;
            Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
        }
    }
}