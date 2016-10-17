using System;
using System.Reflection;

public class BlackBoxInt
{
    private int value = 0;

    private void Add(int addend)
    {
        this.value += addend;
    }

    private void Subtract(int subtrahend)
    {
        this.value -= subtrahend;
    }

    private void Multiply(int multiplier)
    {
        this.value *= multiplier;
    }

    private void Divide(int divider)
    {
        this.value /= divider;
    }

    private void LeftShift(int shifter)
    {
        this.value <<= shifter;
    }

    private void RightShift(int shifter)
    {
        this.value >>= shifter;
    }
}

public class BlackBoxInteger
{
    public static void Main()
    {
        string input = Console.ReadLine();

        BlackBoxInt integer = new BlackBoxInt();

        var type = typeof(BlackBoxInt);
        var field = type.GetField("value", BindingFlags.NonPublic | BindingFlags.Instance);
        
        while (input != "END")
        {
            string[] data = input.Split('_');

            var methodInfo = type.GetMethod(data[0], BindingFlags.Instance | BindingFlags.NonPublic);

            methodInfo.Invoke(integer, new object[] { int.Parse(data[1]) });

            int number = (int)field.GetValue(integer);
            Console.WriteLine(number);

            input = Console.ReadLine();
        }
    }
}