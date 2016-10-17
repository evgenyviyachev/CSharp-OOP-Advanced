using System;
using System.Reflection;

public interface IPerson
{
    string Name { get; }
    int Age { get; }
}

public interface IBirthable
{
    string Birthdate { get; }
}

public interface IIdentifiable
{
    string Id { get; }
}

public class Citizen : IPerson, IBirthable, IIdentifiable
{
    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }

    public int Age { get; set; }

    public string Birthdate { get; set; }

    public string Id { get; set; }

    public string Name { get; set; }
}

public class MultipleImplementation
{
    static void Main()
    {
        Type identifiableInterface = typeof(Citizen).GetInterface("IIdentifiable");
        Type birthableInterface = typeof(Citizen).GetInterface("IBirthable");
        PropertyInfo[] properties = identifiableInterface.GetProperties();
        Console.WriteLine(properties.Length);
        Console.WriteLine(properties[0].PropertyType.Name);
        properties = birthableInterface.GetProperties();
        Console.WriteLine(properties.Length);
        Console.WriteLine(properties[0].PropertyType.Name);
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        string id = Console.ReadLine();
        string birthdate = Console.ReadLine();
        IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
        IBirthable birthable = new Citizen(name, age, id, birthdate);
    }
}