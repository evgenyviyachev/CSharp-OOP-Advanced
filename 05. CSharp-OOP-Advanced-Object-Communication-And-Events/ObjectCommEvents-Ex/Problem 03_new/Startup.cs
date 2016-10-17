using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        string input = Console.ReadLine();
        var calc = new PrimitiveCalculator();

        while (input != "End")
        {
            string[] data = input.Split();

            int num1;
            if (int.TryParse(data[0], out num1))
            {
                int num2 = int.Parse(data[1]);
                int result = calc.PerformCalculation(num1, num2);
                Console.WriteLine(result);
            }
            else
            {
                char @operator = Convert.ToChar(data[1]);
                switch (@operator)
                {
                    case '+':
                        IStrategy addition = new AdditionStrategy();
                        calc.ChangeStrategy(addition);
                        break;
                    case '-':
                        IStrategy subtraction = new SubtractionStrategy();
                        calc.ChangeStrategy(subtraction);
                        break;
                    case '*':
                        IStrategy multiplication = new MultiplicationStrategy();
                        calc.ChangeStrategy(multiplication);
                        break;
                    case '/':
                        IStrategy division = new DivisionStrategy();
                        calc.ChangeStrategy(division);
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operator!");
                }
            }
            input = Console.ReadLine();
        }
    }
}