using System;
using System.Collections.Generic;
using System.Linq;

public interface IIdentifiable
{
    string Id { get; }
}

public class Person : IIdentifiable
{
    public Person(string name, int age, string id)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Id { get; set; }
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

public class BorderControl
{
    static void Main()
    {
        List<IIdentifiable> list = new List<IIdentifiable>();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] data = input.Split();

            if (data.Length == 3)
            {
                Person person = new Person(data[0], int.Parse(data[1]), data[2]);
                list.Add(person);
            }
            else if (data.Length == 2)
            {
                Robot robot = new Robot(data[0], data[1]);
                list.Add(robot);
            }

            input = Console.ReadLine();
        }

        string fakeIdsEnd = Console.ReadLine();

        var detained = list.Where(ii => ii.Id.EndsWith(fakeIdsEnd)).Select(ii => ii.Id);

        foreach (var det in detained)
        {
            Console.WriteLine(det);
        }
    }
}