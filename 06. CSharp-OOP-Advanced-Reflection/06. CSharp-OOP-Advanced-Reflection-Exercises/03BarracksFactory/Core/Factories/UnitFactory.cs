namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;
    using System.Reflection;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type type = Type.GetType("_03BarracksFactory.Models.Units." + unitType);
            IUnit newUnit = (IUnit)Activator.CreateInstance(type);
            return newUnit;
        }
    }
}
