using System;
using System.Collections.Generic;
using System.Linq;

public interface IBuyer
{
    string Name { get; }
    int Age { get; }
    int Food { get; }
    void BuyFood();
}

public class Person : IBuyer
{
    public Person(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthday = birthdate;
        this.Food = 0;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Id { get; set; }
    public string Birthday { get; set; }
    public int Food { get; set; }

    public void BuyFood()
    {
        this.Food += 10;
    }
}

public class Rebel : IBuyer
{
    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
        this.Food = 0;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Group { get; set; }
    public int Food { get; set; }

    public void BuyFood()
    {
        this.Food += 5;
    }
}

public class FoodShortage
{
    static void Main()
    {
        int numberOfPeople = int.Parse(Console.ReadLine());
        List<IBuyer> people = new List<IBuyer>();

        for (int i = 0; i < numberOfPeople; i++)
        {
            string[] data = Console.ReadLine().Split();

            if (data.Length == 4)
            {
                Person person = new Person(data[0], int.Parse(data[1]), data[2], data[3]);
                people.Add(person);
            }
            else if (data.Length == 3)
            {
                Rebel rebel = new Rebel(data[0], int.Parse(data[1]), data[2]);
                people.Add(rebel);
            }
        }

        string input = Console.ReadLine();

        while (input != "End")
        {
            string name = input;

            IBuyer buyer = people.FirstOrDefault(p => p.Name == name);

            if (buyer != null)
            {
                buyer.BuyFood();
            }

            input = Console.ReadLine();
        }

        var food = people.Sum(p => p.Food);

        Console.WriteLine(food);
    }
}