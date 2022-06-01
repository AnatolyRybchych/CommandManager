
namespace CommandManager
{
    public class CommandCommandsResponse
    {
        public CommandManager Mgr { get; private set; }
        public Type Type;
        public CommandCommandsResponse(CommandManager mgr, Type type)
        {
            Type = type;
            Mgr = mgr;
        }

        public override string ToString()
        {
            return new CommandResonseSerializer().Serialize(Mgr.Commands.Where(cmd => cmd.IsTypeForInput(Type)));
        }
    }
}
