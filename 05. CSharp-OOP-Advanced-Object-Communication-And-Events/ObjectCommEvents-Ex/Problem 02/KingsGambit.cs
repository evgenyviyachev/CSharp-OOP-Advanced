using System;
using System.Collections.Generic;
using System.Linq;

public interface IFigure
{
    string Name { get; }
}

public interface IAttackable : IFigure
{
    void UnderAttack();
}

public interface IKillable : IFigure
{
    void Killed();
}

public class King : IFigure, IAttackable
{
    public King(string name)
    {
        this.Name = name;
    }

    public event EventHandler Handler;

    public string Name { get; private set; }

    public void UnderAttack()
    {
        Console.WriteLine($"King {this.Name} is under attack!");
        if (this.Handler != null)
        {
            this.Handler(this, EventArgs.Empty);
        }        
    }
}

public class Footman : IFigure, IKillable
{
    public Footman(string name, King king)
    {
        this.Name = name;
        this.King = king;
        this.Subscribe();
    }

    public string Name { get; private set; }

    public King King { get; private set; }

    private void Subscribe()
    {
        this.King.Handler += King_Handler;
    }

    private void King_Handler(object sender, EventArgs e)
    {
        Console.WriteLine($"Footman {this.Name} is panicking!");
    }

    public void Killed()
    {
        this.King.Handler -= King_Handler;
    }
}

public class RoyalGuard : IFigure, IKillable
{
    public RoyalGuard(string name, King king)
    {
        this.Name = name;
        this.King = king;
        this.Subscribe();
    }

    public string Name { get; private set; }

    public King King { get; private set; }

    private void Subscribe()
    {
        this.King.Handler += King_Handler;
    }

    private void King_Handler(object sender, EventArgs e)
    {
        Console.WriteLine($"Royal Guard {this.Name} is defending!");
    }

    public void Killed()
    {
        this.King.Handler -= King_Handler;
    }
}

public class KingsGambit
{
    public static void Main()
    {
        string kingName = Console.ReadLine();

        King king = new King(kingName);

        List<IKillable> personnel = Console.ReadLine()
            .Split()
            .Select(name => new RoyalGuard(name, king))
            .ToList<IKillable>();

        personnel.AddRange(Console.ReadLine()
            .Split()
            .Select(name => new Footman(name, king))
            .ToList<IKillable>());

        string input = Console.ReadLine();

        while (input != "End")
        {
            if (input.StartsWith("Attack"))
            {
                king.UnderAttack();
            }
            else
            {
                string[] data = input.Split();
                string name = data[1];
                IKillable figure = personnel.First(f => f.Name == name);
                figure.Killed();
            }

            input = Console.ReadLine();
        }
    }
}