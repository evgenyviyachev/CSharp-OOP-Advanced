using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Suit
{
    Clubs = 0,
    Diamonds = 13,
    Hearts = 26,
    Spades = 39
}

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

public class Card
{    
    public Card(Suit suit, Rank rank)
    {
        this.CardSuit = suit;
        this.CardRank = rank;
        this.Power = (int)this.CardSuit + (int)this.CardRank;
    }

    public Suit CardSuit { get; private set; }
    public Rank CardRank { get; private set; }
    public int Power { get; private set; }
}

public class CardPower
{
    public static void Main()
    {
        var cardRank = (Rank)Enum.Parse(typeof(Rank), Console.ReadLine());
        var cardSuit = (Suit)Enum.Parse(typeof(Suit), Console.ReadLine());

        Card card = new Card(cardSuit, cardRank);

        Console.WriteLine($"Card name: {card.CardRank} of {card.CardSuit}; Card power: {card.Power}");
    }
}