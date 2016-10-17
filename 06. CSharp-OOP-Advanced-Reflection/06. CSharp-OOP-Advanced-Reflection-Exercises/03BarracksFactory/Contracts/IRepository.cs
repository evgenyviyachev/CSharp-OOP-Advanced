namespace _03BarracksFactory.Contracts
{
    public interface IRepository
    {
        void AddUnit(IUnit unit);
        string Statistics { get; }
        bool RemoveUnit(string unitType);
    }
}
