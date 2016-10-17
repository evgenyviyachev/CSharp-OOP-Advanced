using _071984.Core;
using _071984.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _071984
{
    public class Startup
    {
        public static void Main()
        {
            Repository repo = new Repository();
            Engine engine = new Engine(repo);
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            engine.Run(numbers[0], numbers[1], numbers[2]);
        }
    }
}
