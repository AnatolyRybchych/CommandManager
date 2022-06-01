
namespace CommandManager
{
    public class IEnumerableClearCommand : CommandWithTypeOrDerivative<IEnumerable<object>>
    {
        public IEnumerableClearCommand(string commandName) : base(commandName)
        {
        }

        public override string Help => "returns empty collection with same type";

        public override object ExecuteCommand(IEnumerable<object> input, CommandManager mgr)
        {
            return typeof(List<>).MakeGenericType(input.GetType().GetGenericArguments().First()).GetConstructor(new Type[0])?.Invoke(new object[0]) ?? new CommandNullResponse();
        }
    }
}
