using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum, AllowMultiple = false)]
public class TypeAttribute : Attribute
{
    public TypeAttribute(string type, string category, string description)
    {
        this.Type = type;
        this.Category = category;
        this.Description = description;
    }

    public string Type { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
}

[Type("Enumeration", "Suit", "Provides suit constants for a Card class.")]
public enum Suit
{
    Clubs = 0,
    Diamonds = 13,
    Hearts = 26,
    Spades = 39
}

[Type("Enumeration", "Rank", "Provides rank constants for a Card class.")]
public enum Rank
{
    Ace = 14,
    Two = 2,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King
}

public class CustomEnumAttribute
{
    public static void Main()
    {
        string specificEnum = Console.ReadLine();

        if (specificEnum == "Rank")
        {
            Type type = typeof(Rank);
            var attribute = type.GetCustomAttributes(false);
            foreach (TypeAttribute attr in attribute)
            {
                Console.WriteLine($"Type = {attr.Type}, Description = {attr.Description}");
            }
        }
        else if (specificEnum == "Suit")
        {
            Type type = typeof(Suit);
            var attribute = type.GetCustomAttributes(false);
            foreach (TypeAttribute attr in attribute)
            {
                Console.WriteLine($"Type = {attr.Type}, Description = {attr.Description}");
            }
        }
    }
}