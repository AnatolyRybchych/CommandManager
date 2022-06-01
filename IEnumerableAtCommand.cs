
namespace CommandManager
{
    public class IEnumerableAtCommand : CommandWithTypeOrDerivative<IEnumerable<object>>
    {
        private IntCommandArgument intArgument;
        public IEnumerableAtCommand(string commandName) : base(commandName)
        {
            intArgument = new IntCommandArgument(true, "index", 0);
            Signeture.Args.Add(intArgument);
        }

        public override string Help => "returns element in collection uisng id, id >= 0";

        public override object ExecuteCommand(IEnumerable<object> input, CommandManager mgr)
        {
            return input.ElementAtOrDefault(intArgument.Value) ?? new CommandNullResponse();
        }
    }
}
