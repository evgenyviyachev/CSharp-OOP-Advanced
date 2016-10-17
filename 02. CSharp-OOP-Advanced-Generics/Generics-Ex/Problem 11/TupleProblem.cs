using System;

public class Tuple<TKey, TValue>
{
    public TKey Key { get; set; }
    public TValue Value { get; set; }

    public override string ToString()
    {
        return $"{this.Key} -> {this.Value}";
    }
}

public class TupleProblem
{
    public static void Main()
    {
        Tuple<string, string> personAddress = new Tuple<string, string>();
        Tuple<string, double> personBeer = new Tuple<string, double>();
        Tuple<int, double> intDouble = new Tuple<int, double>();

        string[] personAddressData = Console.ReadLine().Split();
        string[] personBeerData = Console.ReadLine().Split();
        string[] intDoubleData = Console.ReadLine().Split();

        personAddress.Key = personAddressData[0] + " " + personAddressData[1];
        personAddress.Value = personAddressData[2];

        personBeer.Key = personBeerData[0];
        personBeer.Value = double.Parse(personBeerData[1]);

        intDouble.Key = int.Parse(intDoubleData[0]);
        intDouble.Value = double.Parse(intDoubleData[1]);

        Console.WriteLine(personAddress);
        Console.WriteLine(personBeer);
        Console.WriteLine(intDouble);
    }
}