using System;
using System.Collections.Generic;
using System.Linq;

public interface IIdentifiable
{
    string Id { get; }
}

public interface IBirthable
{
    string Birthday { get; }
}

public class Person : IIdentifiable, IBirthable
{
    public Person(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthday = birthdate;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Id { get; set; }
    public string Birthday { get; set; }
}

public class Pet : IBirthable
{
    public Pet(string name, string birthdate)
    {
        this.Name = name;
        this.Birthday = birthdate;
    }

    public string Name { get; set; }
    public string Birthday { get; set; }
}

public class Robot : IIdentifiable
{
    public Robot(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }

    public string Model { get; set; }
    public string Id { get; set; }
}

public class BirthdayCelebrations
{
    static void Main()
    {
        List<IBirthable> birthdayHavers = new List<IBirthable>();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] data = input.Split();

            switch (data[0])
            {
                case "Citizen":
                    Person citizen = new Person(data[1], int.Parse(data[2]), data[3], data[4]);
                    birthdayHavers.Add(citizen);
                    break;
                case "Pet":
                    Pet pet = new Pet(data[1], data[2]);
                    birthdayHavers.Add(pet);
                    break;
                default:
                    break;
            }

            input = Console.ReadLine();
        }

        string year = Console.ReadLine();

        var years = birthdayHavers.Where(b => b.Birthday.EndsWith(year)).Select(b => b.Birthday);

        //if (years.Count() == 0)
        //{
        //    Console.WriteLine("<no output>");
        //    return;
        //}

        foreach (var currentYear in years)
        {
            Console.WriteLine(currentYear);
        }
    }
}