

namespace CommandManager
{
    internal abstract class Command
    {
        public abstract string Help { get; }
        public CommandSignature Signeture { get; private set; }
        public abstract bool IsTypeForInput(Type type);

        public abstract object Execute(object data, CommandManager mgr);

        public Command(string commandName)
        {
            Signeture = new CommandSignature(commandName);
        }

        public override string ToString()
        {
            return $"{Signeture.CommandName}\trequired[{string.Join(", ", Signeture.Args.Where(arg => arg.IsRequired))}],\tvariadic[{string.Join(", ", Signeture.Args.Where(arg => arg.IsRequired == false))}]\t- {Help}";
        }
    }
}
