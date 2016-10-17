using System;
using System.Reflection;

public interface IPerson
{
    string Name { get; }
    int Age { get; }
}

public class Citizen : IPerson
{
    public Citizen(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public int Age { get; set; }

    public string Name { get; set; }
}

public class Program
{
    static void Main()
    {
        Type personInterface = typeof(Citizen).GetInterface("IPerson");
        PropertyInfo[] properties = personInterface.GetProperties();
        Console.WriteLine(properties.Length);
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        IPerson person = new Citizen(name, age);
        Console.WriteLine(person.Name);
        Console.WriteLine(person.Age);
    }
}