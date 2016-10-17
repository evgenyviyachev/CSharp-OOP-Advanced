using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PrimitiveCalculator
{
    private IStrategy strategy;

    public PrimitiveCalculator(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public PrimitiveCalculator()
        : this(new AdditionStrategy())
    {
    }

    public void ChangeStrategy(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        return this.strategy.Calculate(firstOperand, secondOperand);
    }
}