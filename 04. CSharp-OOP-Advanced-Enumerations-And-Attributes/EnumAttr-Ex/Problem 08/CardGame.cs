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

public class Person
{
    private int counter;
    private string name;
    private Card[] cards;

    public Person(string name)
    {
        this.name = name;
        this.counter = 0;
        this.cards = new Card[5];
        this.IsFull = false;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            this.name = value;
        }
    }

    public bool IsFull { get; private set; }

    public void AddCard(Card card)
    {
        if (this.counter < 5)
        {
            this.cards[this.counter] = card;
            this.counter++;

            if (this.counter == 5)
            {
                this.IsFull = true;
            }
        }
    }

    public Card GetMaxCard()
    {
        Card card = this.cards[0];

        for (int i = 1; i < this.cards.Length; i++)
        {
            Card currentCard = this.cards[i];
            if (currentCard.CompareTo(card) > 0)
            {
                card = currentCard;
            }
        }

        return card;
    }
}

public class CardGame
{
    public static void Main()
    {
        Person firstPerson = new Person(Console.ReadLine());
        Person secondPerson = new Person(Console.ReadLine());
        List<Card> usedCards = new List<Card>();

        FillPersonCards(firstPerson, usedCards);
        FillPersonCards(secondPerson, usedCards);

        int result = firstPerson.GetMaxCard().CompareTo(secondPerson.GetMaxCard());

        if (result > 0)
        {
            Console.WriteLine($"{firstPerson.Name} wins with {firstPerson.GetMaxCard().CardRank} of {firstPerson.GetMaxCard().CardSuit}.");
        }
        else
        {
            Console.WriteLine($"{secondPerson.Name} wins with {secondPerson.GetMaxCard().CardRank} of {secondPerson.GetMaxCard().CardSuit}.");
        }
    }

    public static void FillPersonCards(Person person, List<Card> usedCards)
    {
        while (!person.IsFull)
        {
            string[] cardData = Console.ReadLine().Split();

            string rank = cardData[0];
            string suit = cardData[2];

            if (Enum.IsDefined(typeof(Rank), rank)
                && Enum.IsDefined(typeof(Suit), suit))
            {
                if (!usedCards.Any(c => c.CardRank.ToString() == rank && c.CardSuit.ToString() == suit))
                {
                    Card card = new Card((Suit)Enum.Parse(typeof(Suit), suit), (Rank)Enum.Parse(typeof(Rank), rank));
                    person.AddCard(card);
                    usedCards.Add(card);
                }
                else
                {
                    Console.WriteLine("Card is not in the deck.");
                }
            }
            else
            {
                Console.WriteLine("No such card exists.");
            }
        }
    }
}