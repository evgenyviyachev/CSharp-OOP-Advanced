using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICallable
{
    void CallNumber(string number);
}

public interface IBrowsable
{
    void BrowseSite(string site);
}

public class SmartPhone : ICallable, IBrowsable
{
    public void BrowseSite(string site)
    {
        foreach (var character in site)
        {
            if (char.IsDigit(character))
            {
                Console.WriteLine("Invalid URL!");
                return;
            }
        }
        Console.WriteLine($"Browsing: {site}!");
    }

    public void CallNumber(string number)
    {
        foreach (var character in number)
        {
            if (!char.IsDigit(character))
            {
                Console.WriteLine("Invalid number!");
                return;
            }
        }
        Console.WriteLine($"Calling... {number}");
    }
}

public class Telephony
{
    static void Main()
    {
        List<string> numbers = Console.ReadLine().Split().Select(x => x.Trim()).ToList();
        List<string> sites = Console.ReadLine().Split().Select(x => x.Trim()).ToList();

        SmartPhone sp = new SmartPhone();

        foreach (var number in numbers)
        {
            sp.CallNumber(number);
        }
        foreach (var site in sites)
        {
            sp.BrowseSite(site);
        }
    }
}