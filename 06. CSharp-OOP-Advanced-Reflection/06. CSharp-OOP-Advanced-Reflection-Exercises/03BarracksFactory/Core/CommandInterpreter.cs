namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using Attributes;
    using Contracts;
    using Commands;
    using System.Reflection;
    
    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            object[] parametersForConstruction = new object[]
            {
                data
            };

            Type typeOfCommand = Assembly.GetExecutingAssembly()
                .GetTypes()
                .First(type => type.GetCustomAttributes(typeof(AliasAttribute))
                .Where(atr => atr.Equals(commandName))
                .ToArray().Length > 0);

            Type typeOfInterpreter = typeof(CommandInterpreter);

            Command exe = (Command)Activator.CreateInstance(typeOfCommand, parametersForConstruction);

            FieldInfo[] commandFields = typeOfCommand
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo[] interpreterFields = typeOfInterpreter
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var commandField in commandFields)
            {
                Attribute injectAttr = commandField.GetCustomAttribute(typeof(InjectAttribute));

                if (injectAttr != null)
                {
                    if (interpreterFields.Any(f => f.FieldType == commandField.FieldType))
                    {
                        FieldInfo field = interpreterFields.First(f => f.FieldType == commandField.FieldType);
                        commandField.SetValue(exe, field.GetValue(this));
                    }
                }
            }

            return exe;
        }
    }
}
