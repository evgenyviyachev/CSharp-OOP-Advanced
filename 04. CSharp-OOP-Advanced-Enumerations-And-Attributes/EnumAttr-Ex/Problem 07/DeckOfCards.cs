using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Suit
{
    Clubs,
    Hearts,
    Diamonds,
    Spades
}

public enum Rank
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

public class DeckOfCards
{
    public static void Main()
    {
        var suits = Enum.GetValues(typeof(Suit)).OfType<Suit>().ToList();
        var ranks = Enum.GetValues(typeof(Rank)).OfType<Rank>().ToList();

        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
                Console.WriteLine($"{rank} of {suit}");
            }
        }
    }
}