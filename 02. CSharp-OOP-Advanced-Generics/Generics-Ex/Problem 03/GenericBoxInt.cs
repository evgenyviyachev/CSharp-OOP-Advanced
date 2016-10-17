using System;

public class Box<T>
{
    public Box(T item)
    {
        this.Value = item;
    }

    public T Value { get; set; }

    public override string ToString()
    {
        return $"{this.Value.GetType().FullName}: {this.Value}";
    }
}

public class GenericBoxInt
{
    public static void Main()
    {
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
            Console.WriteLine(box);
        }
    }
}