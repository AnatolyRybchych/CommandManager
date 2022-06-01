
namespace CommandManager
{
    public abstract class CommandWithTypeOrDerivative<T> : Command
    {
        public CommandWithTypeOrDerivative(string commandName) : base(commandName)
        {
        }

        public override bool IsTypeForInput(Type type)
        {
            return typeof(T).IsAssignableFrom(type);
        }

        public override object Execute(object data, CommandManager mgr)
        {
            if (data is T)
                return ExecuteCommand((T)data, mgr);
            else
                throw new InvalidCastException($"{data.GetType().Name} to {typeof(T).Name}");
        }

        public abstract object ExecuteCommand(T input, CommandManager mgr);
    }
}
