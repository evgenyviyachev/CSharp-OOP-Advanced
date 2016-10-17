using System;
using System.Collections.Generic;
using System.Linq;

[Custom("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
public abstract class Weapon
{
    public Weapon(string name, Rarity rarity)
    {
        this.Name = name;
        this.Rarity = rarity;
        this.Strength = 0;
        this.Agility = 0;
        this.Vitality = 0;
    }

    public string Name { get; private set; }

    public int MinDamage { get; protected set; }

    public int MaxDamage { get; protected set; }

    public Gem[] Sockets { get; protected set; }

    public Rarity Rarity { get; protected set; }

    public int Strength { get; protected set; }

    public int Agility { get; protected set; }

    public int Vitality { get; protected set; }

    public override string ToString()
    {
        this.CalculateStats();
        return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
    }

    private void CalculateStats()
    {
        int multiplier = (int)this.Rarity;
        this.MinDamage *= multiplier;
        this.MaxDamage *= multiplier;

        for (int i = 0; i < this.Sockets.Length; i++)
        {
            if (this.Sockets[i] != null)
            {
                Gem gem = this.Sockets[i];
                this.MinDamage += (gem.Strength * 2 + gem.Agility * 1);
                this.MaxDamage += (gem.Strength * 3 + gem.Agility * 4);
                this.Strength += gem.Strength;
                this.Agility += gem.Agility;
                this.Vitality += gem.Vitality;
            }
        }
    }

    public void AddGemInSocket(Gem gem, int socketNum)
    {
        if (socketNum < 0 || socketNum >= this.Sockets.Length)
        {
            return;
        }

        this.Sockets[socketNum] = gem;
    }

    public void RemoveGemFromSocket(int socketNum)
    {
        if (socketNum < 0 || socketNum >= this.Sockets.Length
            || this.Sockets[socketNum] == null)
        {
            return;
        }

        this.Sockets[socketNum] = null;
    }
}

public class Axe : Weapon
{
    private const int NumberOfSockets = 4;
    private const int MinDamageValue = 5;
    private const int MaxDamageValue = 10;

    public Axe(string name, Rarity rarity)
        : base(name, rarity)
    {
        this.MinDamage = MinDamageValue;
        this.MaxDamage = MaxDamageValue;
        this.Sockets = new Gem[NumberOfSockets];
    }
}

public class Sword : Weapon
{
    private const int NumberOfSockets = 3;
    private const int MinDamageValue = 4;
    private const int MaxDamageValue = 6;

    public Sword(string name, Rarity rarity)
        : base(name, rarity)
    {
        this.MinDamage = MinDamageValue;
        this.MaxDamage = MaxDamageValue;
        this.Sockets = new Gem[NumberOfSockets];
    }
}

public class Knife : Weapon
{
    private const int NumberOfSockets = 2;
    private const int MinDamageValue = 3;
    private const int MaxDamageValue = 4;

    public Knife(string name, Rarity rarity)
        : base(name, rarity)
    {
        this.MinDamage = MinDamageValue;
        this.MaxDamage = MaxDamageValue;
        this.Sockets = new Gem[NumberOfSockets];
    }
}

public abstract class Gem
{
    public Gem(Clarity clarity)
    {
        this.Clarity = clarity;
    }

    public int Strength { get; protected set; }

    public int Agility { get; protected set; }

    public int Vitality { get; protected set; }

    public Clarity Clarity { get; protected set; }

    protected void ChangeStats()
    {
        int addition = (int)this.Clarity;
        this.Strength += addition;
        this.Agility += addition;
        this.Vitality += addition;
    }
}

public class Ruby : Gem
{
    private int StrengthValue = 7;
    private int AgilityValue = 2;
    private int VitailityValue = 5;

    public Ruby(Clarity clarity)
        : base(clarity)
    {
        this.Strength = StrengthValue;
        this.Agility = AgilityValue;
        this.Vitality = VitailityValue;
        this.ChangeStats();
    }
}

public class Emerald : Gem
{
    private int StrengthValue = 1;
    private int AgilityValue = 4;
    private int VitailityValue = 9;

    public Emerald(Clarity clarity)
        : base(clarity)
    {
        this.Strength = StrengthValue;
        this.Agility = AgilityValue;
        this.Vitality = VitailityValue;
        this.ChangeStats();
    }
}

public class Amethyst : Gem
{
    private int StrengthValue = 2;
    private int AgilityValue = 8;
    private int VitailityValue = 4;

    public Amethyst(Clarity clarity)
            : base(clarity)
    {
        this.Strength = StrengthValue;
        this.Agility = AgilityValue;
        this.Vitality = VitailityValue;
        this.ChangeStats();
    }
}

public enum WeaponType
{
    Axe = 4,
    Sword = 3,
    Knife = 2
}

public enum Rarity
{
    Common = 1,
    Uncommon = 2,
    Rare = 3,
    Epic = 5
}

public enum GemType
{
    Ruby,
    Emerald,
    Amethyst
}

public enum Clarity
{
    Chipped = 1,
    Regular = 3,
    Perfect = 5,
    Flawless = 10
}

public interface IExecutable
{
    void Execute();
}

public interface IInterpreter
{
    void InterpretCommand(string input);
}

public class CommandInterpreter : IInterpreter
{
    public void InterpretCommand(string input)
    {
        string[] data = input.Split(';');
        string commandName = data[0];
        IExecutable command = this.ParseCommand(commandName, data);
        command.Execute();
    }

    private IExecutable ParseCommand(string commandName, string[] data)
    {
        switch (commandName)
        {
            case "Create":
                return new CreateCommand(data);
            case "Add":
                return new AddCommand(data);
            case "Remove":
                return new RemoveCommand(data);
            case "Print":
                return new PrintCommand(data);
            case "Author":
                return new AuthorCommand();
            case "Revision":
                return new RevisionCommand();
            case "Description":
                return new DescriptionCommand();
            case "Reviewers":
                return new ReviewersCommand();
            default:
                throw new Exception();
        }
    }
}

public abstract class Command : IExecutable
{
    public abstract void Execute();
}

public class CreateCommand : Command
{
    public CreateCommand(string[] data)
    {
        this.Data = data;
    }

    public string[] Data { get; private set; }

    public override void Execute()
    {
        string[] rarityType = this.Data[1].Split();

        Rarity rarity = (Rarity)Enum.Parse(typeof(Rarity), rarityType[0]);
        string weaponType = rarityType[1];

        switch (weaponType)
        {
            case "Axe":
                Weapons.StaticWeapons.Add(new Axe(this.Data[2], rarity));
                break;
            case "Sword":
                Weapons.StaticWeapons.Add(new Sword(this.Data[2], rarity));
                break;
            case "Knife":
                Weapons.StaticWeapons.Add(new Knife(this.Data[2], rarity));
                break;
            default:
                break;
        }
    }
}

public class AddCommand : Command
{
    public AddCommand(string[] data)
    {
        this.Data = data;
    }

    public string[] Data { get; private set; }

    public override void Execute()
    {
        string weaponName = this.Data[1];
        int socketIndex = int.Parse(this.Data[2]);
        string[] gemInfo = this.Data[3].Split();

        string gemType = gemInfo[1];
        Clarity clarity = (Clarity)Enum.Parse(typeof(Clarity), gemInfo[0]);

        Weapon weapon = Weapons.StaticWeapons.FirstOrDefault(w => w.Name == weaponName);

        if (weapon == null)
        {
            return;
        }

        switch (gemType)
        {
            case "Ruby":
                weapon.AddGemInSocket(new Ruby(clarity), socketIndex);
                break;
            case "Emerald":
                weapon.AddGemInSocket(new Emerald(clarity), socketIndex);
                break;
            case "Amethyst":
                weapon.AddGemInSocket(new Amethyst(clarity), socketIndex);
                break;
            default:
                break;
        }
    }
}

public class RemoveCommand : Command
{
    public RemoveCommand(string[] data)
    {
        this.Data = data;
    }

    public string[] Data { get; private set; }

    public override void Execute()
    {
        string weaponName = this.Data[1];
        int socketIndex = int.Parse(this.Data[2]);

        Weapon weapon = Weapons.StaticWeapons.FirstOrDefault(w => w.Name == weaponName);

        if (weapon == null)
        {
            return;
        }

        weapon.RemoveGemFromSocket(socketIndex);
    }
}

public class PrintCommand : Command
{
    public PrintCommand(string[] data)
    {
        this.Data = data;
    }

    public string[] Data { get; private set; }

    public override void Execute()
    {
        string weaponName = this.Data[1];

        Weapon weapon = Weapons.StaticWeapons.FirstOrDefault(w => w.Name == weaponName);

        if (weapon == null)
        {
            return;
        }

        OutputWriter.DisplayOnNewLine(weapon.ToString());
    }
}

public class AuthorCommand : Command
{
    public override void Execute()
    {
        var attributes = typeof(Weapon)
            .GetCustomAttributes(false)
            .Select(x => (CustomAttribute)x);

        CustomAttribute attr = null;

        foreach (var att in attributes)
        {
            attr = att;
        }

        OutputWriter.DisplayOnNewLine($"Author: {attr.Author}");
    }
}

public class RevisionCommand : Command
{
    public override void Execute()
    {
        var attributes = typeof(Weapon)
            .GetCustomAttributes(false)
            .Select(x => (CustomAttribute)x);

        CustomAttribute attr = null;

        foreach (var att in attributes)
        {
            attr = att;
        }

        OutputWriter.DisplayOnNewLine($"Revision: {attr.Revision}");
    }
}

public class DescriptionCommand : Command
{
    public override void Execute()
    {
        var attributes = typeof(Weapon)
            .GetCustomAttributes(false)
            .Select(x => (CustomAttribute)x);

        CustomAttribute attr = null;

        foreach (var att in attributes)
        {
            attr = att;
        }

        OutputWriter.DisplayOnNewLine($"Class description: {attr.Description}");
    }
}

public class ReviewersCommand : Command
{
    public override void Execute()
    {
        var attributes = typeof(Weapon)
            .GetCustomAttributes(false)
            .Select(x => (CustomAttribute)x);

        CustomAttribute attr = null;

        foreach (var att in attributes)
        {
            attr = att;
        }

        OutputWriter.DisplayOnNewLine($"Reviewers: {string.Join(", ", attr.Reviewers)}");
    }
}

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

public static class OutputWriter
{
    public static void DisplayOnNewLine(string input)
    {
        Console.WriteLine(input);
    }
}

public static class Weapons
{
    public static List<Weapon> StaticWeapons = new List<Weapon>();
}

public class InfernoInfinity
{
    public static void Main()
    {
        IInterpreter interpreter = new CommandInterpreter();

        string input = Console.ReadLine();

        while (input != "END")
        {
            interpreter.InterpretCommand(input);
            input = Console.ReadLine();
        }
    }
}