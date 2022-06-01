
namespace CommandManager
{
    internal class IEnumerableSaveCommand<T> : CommandWithTypeOrDerivative<IEnumerable<T>>
    {
        public Action<IEnumerable<T>> SavingAction { get; private set; }

        public override string Help => "saves collection state";

        public IEnumerableSaveCommand(string commandName, Action<IEnumerable<T>> savingAction) : base(commandName)
        {
            SavingAction = savingAction;
        }

        public override object ExecuteCommand(IEnumerable<T> input, CommandManager mgr)
        {
            SavingAction(input);
            return input;
        }
    }
}
