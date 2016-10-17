namespace _03BarracksFactory.Core.Commands
{
    using System;
    using Contracts;
    using Attributes;

    [Alias("fight")]
    public class FightCommand : Command
    {
        public FightCommand(string[] data = null)
            : base(data)
        {
        }

        public override string Execute()
        {
            this.Quit();
            return string.Empty;
        }

        private void Quit()
        {
            Environment.Exit(0);
        }
    }
}
