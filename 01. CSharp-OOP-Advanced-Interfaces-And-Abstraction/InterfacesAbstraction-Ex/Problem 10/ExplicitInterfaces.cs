using System;

public interface IResident
{
    string Name { get; }
    string Country { get; }
    string GetName();
}

public interface IPerson
{
    string Name { get; }
    int Age { get; }
    string GetName();
}

public class Citizen : IPerson, IResident
{
    private string name;
    private string country;
    private int age;

    public Citizen(string name, string country, int age)
    {
        this.name = name;
        this.country = country;
        this.age = age;
    }

    public int Age
    {
        get
        {
            return this.age;
        }
    }

    public string Country
    {
        get
        {
            return this.country;
        }
    }

    string IPerson.Name
    {
        get
        {
            return this.name;
        }
    }

    string IResident.Name
    {
        get
        {
            return $"Mr/Ms/Mrs {this.name}";
        }
    }

    string IPerson.GetName()
    {
        return this.name;
    }

    string IResident.GetName()
    {
        return $"Mr/Ms/Mrs {this.name}";
    }
}

public class ExplicitInterfaces
{
    static void Main()
    {
        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] data = input.Split();

            Citizen citizen = new Citizen(data[0], data[1], int.Parse(data[2]));

            IPerson person = (IPerson)citizen;
            IResident resident = (IResident)citizen;

            Console.WriteLine(person.GetName());
            Console.WriteLine(resident.GetName());

            input = Console.ReadLine();
        }
    }
}