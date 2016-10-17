using System;

public class Threeuple<TFirst, TSecond, TThird>
{
    public TFirst First { get; set; }
    public TSecond Second { get; set; }
    public TThird Third { get; set; }

    public override string ToString()
    {
        return $"{this.First} -> {this.Second} -> {this.Third}";
    }
}

public class ThreeupleProblem
{
    public static void Main()
    {
        Threeuple<string, string, string> personAddressTown = new Threeuple<string, string, string>();
        Threeuple<string, int, bool> personBeerDrunk = new Threeuple<string, int, bool>();
        Threeuple<string, double, string> personBalanceBank = new Threeuple<string, double, string>();

        string[] personAddressTownData = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] personBeerDrunkData = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] personBalanceBankData = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        personAddressTown.First = personAddressTownData[0] + " " + personAddressTownData[1];
        personAddressTown.Second = personAddressTownData[2];
        personAddressTown.Third = personAddressTownData[3];

        personBeerDrunk.First = personBeerDrunkData[0];
        personBeerDrunk.Second = int.Parse(personBeerDrunkData[1]);
        if (personBeerDrunkData[2].ToLower() == "drunk")
        {
            personBeerDrunk.Third = true;
        }
        else
        {
            personBeerDrunk.Third = false;
        }

        personBalanceBank.First = personBalanceBankData[0];
        personBalanceBank.Second = double.Parse(personBalanceBankData[1]);
        personBalanceBank.Third = personBalanceBankData[2];

        Console.WriteLine(personAddressTown);
        Console.WriteLine(personBeerDrunk);
        Console.WriteLine(personBalanceBank);
    }
}