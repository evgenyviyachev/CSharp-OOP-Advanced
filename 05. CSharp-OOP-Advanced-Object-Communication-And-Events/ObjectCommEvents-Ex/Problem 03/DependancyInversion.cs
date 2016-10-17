using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AdditionStrategy
{
    public int Calculate(int firstOperand, int secondOperand)
    {
        return firstOperand + secondOperand;
    }
}

public class SubtractionStrategy
{
    public int Calculate(int firstOperand, int secondOperand)
    {
        return firstOperand - secondOperand;
    }
}

public class MultiplicationStrategy
{
    public int Calculate(int firstOperand, int secondOperand)
    {
        return firstOperand * secondOperand;
    }
}

public class DivisionStrategy
{
    public int Calculate(int firstOperand, int secondOperand)
    {
        return firstOperand / secondOperand;
    }
}

public enum Operation
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

public class PrimitiveCalculator
{
    private AdditionStrategy additionStrategy;
    private SubtractionStrategy subtractionStrategy;
    private MultiplicationStrategy multiplicationStrategy;
    private DivisionStrategy divisionStrategy;
    private Operation operation;

    public PrimitiveCalculator()
    {
        this.additionStrategy = new AdditionStrategy();
        this.subtractionStrategy = new SubtractionStrategy();
        this.multiplicationStrategy = new MultiplicationStrategy();
        this.divisionStrategy = new DivisionStrategy();
        this.operation = Operation.Addition;
    }

    public void ChangeStrategy(char @operator)
    {
        switch (@operator)
        {
            case '+':
                this.operation = Operation.Addition;
                break;
            case '-':
                this.operation = Operation.Subtraction;
                break;
            case '*':
                this.operation = Operation.Multiplication;
                break;
            case '/':
                this.operation = Operation.Division;
                break;
        }
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        int identificator = (int)this.operation;

        if (identificator == 0)
        {
            return this.additionStrategy.Calculate(firstOperand, secondOperand);
        }
        else if (identificator == 1)
        {
            return this.subtractionStrategy.Calculate(firstOperand, secondOperand);
        }
        else if (identificator == 2)
        {
            return this.multiplicationStrategy.Calculate(firstOperand, secondOperand);
        }
        else
        {
            return this.divisionStrategy.Calculate(firstOperand, secondOperand);
        }
    }
}

public class DependancyInversion
{
    public static void Main()
    {
        string input = Console.ReadLine();

        PrimitiveCalculator calc = new PrimitiveCalculator();

        while (input != "End")
        {
            string[] data = input.Split();

            int num1;
            if (int.TryParse(data[0], out num1))
            {
                int num2 = int.Parse(data[1]);
                Console.WriteLine(calc.PerformCalculation(num1, num2));
            }
            else
            {
                char @operator = Convert.ToChar(data[1]);
                calc.ChangeStrategy(@operator);
            }

            input = Console.ReadLine();
        }
    }
}