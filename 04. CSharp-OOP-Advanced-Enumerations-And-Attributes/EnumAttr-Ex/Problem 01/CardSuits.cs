using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Suits
{
    Clubs,
    Diamonds,
    Hearts,
    Spades
}

public class CardSuits
{
    public static void Main()
    {
        string str = Console.ReadLine();

        Array suits = Enum.GetValues(typeof(Suits));

        Console.WriteLine(str + ":");

        foreach (var suit in suits)
        {
            Console.WriteLine($"Ordinal value: {(int)suit}; Name value: {suit}");
        }
    }
}