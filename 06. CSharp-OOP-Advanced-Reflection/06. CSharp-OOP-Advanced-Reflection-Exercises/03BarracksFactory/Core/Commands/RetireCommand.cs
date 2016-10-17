namespace _03BarracksFactory.Core.Commands
{
    using Contracts;
    using Attributes;

    [Alias("retire")]
    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            
            bool hasUnit = this.repository.RemoveUnit(unitType);
            string output = string.Empty;

            if (hasUnit)
            {
                output = unitType + " retired!";
            }
            else
            {
                output = "No such units in repository.";
            }
            
            return output;
        }
    }
}
