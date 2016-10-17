using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Ranks
{
    Ace,
    Two,
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

public class CardRank
{
    public static void Main()
    {
        string str = Console.ReadLine();

        Array ranks = Enum.GetValues(typeof(Ranks));

        Console.WriteLine(str + ":");

        foreach (var rank in ranks)
        {
            Console.WriteLine($"Ordinal value: {(int)rank}; Name value: {rank}");
        }
    }
}