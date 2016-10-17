using System;

public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

public class NameChangeEventArgs : EventArgs
{
    public NameChangeEventArgs(string name)
    {
        this.Name = name;
    }

    public string Name { get; private set; }
}

public class Dispatcher
{
    private string name;

    public event NameChangeEventHandler NameChange;

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.Start(new NameChangeEventArgs(value));
        }
    }

    private void Start(NameChangeEventArgs args)
    {        
        this.NameChange(this, args);
    }

    public void Subscribe()
    {
        this.NameChange += DispatcherNameChange;
    }

    private void DispatcherNameChange(object sender, NameChangeEventArgs args)
    {
        this.name = args.Name;
        Console.WriteLine($"Dispatcher's name changed to {this.Name}.");
    }
}

public class EventImplementation
{
    public static void Main()
    {
        string input = Console.ReadLine();
        Dispatcher dispatcher = new Dispatcher();
        dispatcher.Subscribe();

        while (input != "End")
        {
            dispatcher.Name = input;
            input = Console.ReadLine();
        }
    }
}