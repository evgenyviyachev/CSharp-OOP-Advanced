using System;
using System.Collections.Generic;
using System.Linq;

public class CustomAttribute : Attribute
{
    public CustomAttribute(string author, int revision, string description, params string[] reviewers)
    {
        this.Author = author;
        this.Revision = revision;
        this.Description = description;
        this.Reviewers = reviewers.ToList();
    }

    public string Author { get; private set; }
    public int Revision { get; private set; }
    public string Description { get; private set; }
    public List<string> Reviewers { get; private set; }
}

[Custom("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
public class CreateCCA
{
    public static void Main()
    {
        string input = Console.ReadLine();

        var attributes = typeof(CreateCCA)
            .GetCustomAttributes(false)
            .Select(x => (CustomAttribute)x);

        CustomAttribute attr = null;

        foreach (var att in attributes)
        {
            attr = att;
        }

        while (input != "END")
        {
            switch (input)
            {
                case "Author":
                    Console.WriteLine($"Author: {attr.Author}");
                    break;
                case "Revision":
                    Console.WriteLine($"Revision: {attr.Revision}");
                    break;
                case "Description":
                    Console.WriteLine($"Class description: {attr.Description}");
                    break;
                case "Reviewers":
                    Console.WriteLine($"Reviewers: {string.Join(", ", attr.Reviewers)}");
                    break;
                default:
                    break;
            }
            input = Console.ReadLine();
        }
    }
}