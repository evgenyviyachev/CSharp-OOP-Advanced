using System;

public interface IBrakable
{
    string Brake();
}

public interface IAcceleratable
{
    string PushGas();
}

public interface ICar
{
    string Driver { get; }
}

public class Ferrari : IBrakable, IAcceleratable, ICar
{
    private const string ModelOfCar = "488-Spider";

    public Ferrari(string driver)
    {
        this.Driver = driver;
        this.Model = ModelOfCar;
    }

    public string Driver { get; private set; }

    public string Model { get; private set; }

    public string Brake()
    {
        return "Brakes!";
    }

    public string PushGas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.Brake()}/{this.PushGas()}/{this.Driver}";
    }
}

public class FerrariProblem
{
    static void Main()
    {
        string driver = Console.ReadLine();

        Ferrari ferrari = new Ferrari(driver);

        Console.WriteLine(ferrari);

        string ferrariName = typeof(Ferrari).Name;
        string iCarInterfaceName = typeof(ICar).Name;

        bool isCreated = typeof(ICar).IsInterface;
        if (!isCreated)
        {
            throw new Exception("No interface ICar was created");
        }
    }
}