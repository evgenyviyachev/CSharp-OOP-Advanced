
using System;
using System.Reflection;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Text;
using System.Threading;

public class HarvestingFieldsTest
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        while (input != "HARVEST")
        {
            var type = typeof(HarvestingFields);
            FieldInfo[] fields = null;

            switch (input)
            {
                case "public":
                    fields = type.GetFields();
                    foreach (var field in fields)
                    {
                        Console.WriteLine($"public {field.FieldType.Name} {field.Name}");
                    }
                    break;
                case "protected":
                    fields = type.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
                    foreach (var field in fields)
                    {
                        if (field.IsFamily)
                        {
                            Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                        }
                    }
                    break;
                case "private":
                    fields = type.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
                    foreach (var field in fields)
                    {
                        if (field.IsPrivate)
                        {
                            Console.WriteLine($"private {field.FieldType.Name} {field.Name}");
                        }
                    }
                    break;
                case "all":
                    fields = type.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    foreach (var field in fields)
                    {
                        if (field.IsFamily)
                        {
                            Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                        }
                        else if (field.IsPrivate)
                        {
                            Console.WriteLine($"private {field.FieldType.Name} {field.Name}");
                        }
                        else if (field.IsPublic)
                        {
                            Console.WriteLine($"public {field.FieldType.Name} {field.Name}");
                        }
                        else
                        {
                            Console.WriteLine($"internal {field.FieldType.Name} {field.Name}");
                        }
                    }
                    break;
                default:
                    break;
            }

            input = Console.ReadLine();
        }
    }
}


public class HarvestingFields
{
    private int testInt;
    public double testDouble;
    protected string testString;
    private long testLong;
    protected double aDouble;
    public string aString;
    private Calendar aCalendar;
    public StringBuilder aBuilder;
    private char testChar;
    public short testShort;
    protected byte testByte;
    public byte aByte;
    protected StringBuilder aBuffer;
    private BigInteger testBigInt;
    protected BigInteger testBigNumber;
    protected float testFloat;
    public float aFloat;
    private Thread aThread;
    public Thread testThread;
    private object aPredicate;
    protected object testPredicate;
    public object anObject;
    private object hiddenObject;
    protected object fatherMotherObject;
    private string anotherString;
    protected string moarString;
    public int anotherIntBitesTheDust;
    private Exception internalException;
    protected Exception inheritableException;
    public Exception justException;
    public Stream aStream;
    protected Stream moarStreamz;
    private Stream secretStream;
}