using System;
using System.Collections.Generic;

public interface IAddable
{
    int Add(string addition);
}

public interface IRemovable
{
    string Remove();
}

public interface IUsed
{
    int Used { get; }
}

public class AddCollection : IAddable
{
    public AddCollection()
    {
        this.List = new List<string>();
    }

    public List<string> List { get; private set; }

    public int Add(string addition)
    {
        this.List.Add(addition);
        return this.List.Count - 1;
    }
}

public class AddRemoveCollection : IAddable, IRemovable
{
    public AddRemoveCollection()
    {
        this.List = new List<string>();
    }

    public List<string> List { get; private set; }

    public int Add(string addition)
    {
        this.List.Insert(0, addition);
        return 0;
    }

    public string Remove()
    {
        string lastItem = this.List[this.List.Count - 1];
        this.List.RemoveAt(this.List.Count - 1);
        return lastItem;
    }
}

public class MyList : IUsed, IAddable, IRemovable
{
    public MyList()
    {
        this.Used = 0;
        this.List = new List<string>();
    }

    public int Used { get; private set; }
    public List<string> List { get; private set; }

    public int Add(string addition)
    {
        this.List.Insert(0, addition);
        this.Used++;
        return 0;
    }

    public string Remove()
    {
        string firstItem = this.List[0];
        this.List.RemoveAt(0);
        this.Used--;
        return firstItem;
    }
}

public class CollectionHierarchy
{
    static void Main()
    {
        AddCollection addCollection = new AddCollection();
        AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
        MyList myList = new MyList();

        string[] data = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        List<int> addColAdded = new List<int>();
        List<int> addRemColAdded = new List<int>();
        List<int> myListAdded = new List<int>();

        List<string> addRemColRemoved = new List<string>();
        List<string> myListRemoved = new List<string>();

        for (int i = 0; i < data.Length; i++)
        {
            string addition = data[i];

            addColAdded.Add(addCollection.Add(addition));
            addRemColAdded.Add(addRemoveCollection.Add(addition));
            myListAdded.Add(myList.Add(addition));
        }

        int numberOfRemoveOperations = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfRemoveOperations; i++)
        {
            addRemColRemoved.Add(addRemoveCollection.Remove());
            myListRemoved.Add(myList.Remove());
        }

        Console.WriteLine(string.Join(" ", addColAdded));
        Console.WriteLine(string.Join(" ", addRemColAdded));
        Console.WriteLine(string.Join(" ", myListAdded));

        Console.WriteLine(string.Join(" ", addRemColRemoved));
        Console.WriteLine(string.Join(" ", myListRemoved));
    }
}