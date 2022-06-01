
namespace CommandManager
{
    internal class CommandsCommand : CommandWithTypeOrDerivative<object>
    {
        public CommandsCommand(string commandName) : base(commandName)
        {
        }

        public override string Help => "returns list of commands for this type";

        public override object ExecuteCommand(object input, CommandManager mgr)
        {
            return new CommandCommandsResponse(mgr, input.GetType());
        }
    }
}
