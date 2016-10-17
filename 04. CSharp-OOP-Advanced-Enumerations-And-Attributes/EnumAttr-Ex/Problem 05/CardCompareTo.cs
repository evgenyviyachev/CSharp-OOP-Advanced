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

public class Card : IComparable<Card>
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

    public override string ToString()
    {
        return $"Card name: {this.CardRank} of {this.CardSuit}; Card power: {this.Power}";
    }

    public int CompareTo(Card other)
    {
        return this.Power.CompareTo(other.Power);
    }
}

public class CardCompareTo
{
    public static void Main()
    {
        var cardRank1 = (Rank)Enum.Parse(typeof(Rank), Console.ReadLine());
        var cardSuit1 = (Suit)Enum.Parse(typeof(Suit), Console.ReadLine());

        Card card1 = new Card(cardSuit1, cardRank1);

        var cardRank2 = (Rank)Enum.Parse(typeof(Rank), Console.ReadLine());
        var cardSuit2 = (Suit)Enum.Parse(typeof(Suit), Console.ReadLine());

        Card card2 = new Card(cardSuit2, cardRank2);

        if (card1.CompareTo(card2) > 0)
        {
            Console.WriteLine(card1);
        }
        else
        {
            Console.WriteLine(card2);
        }
    }
}