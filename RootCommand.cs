
namespace CommandManager
{
    public class RootCommandToken {
        public string[] Args { get; private set; }
        public object InitialData { get; private set; }
        public RootCommandToken(string[] args, object initialData)
        {
            Args = args;
            InitialData = initialData;
        }
    }

    public class RootCommand : CommandWithType<RootCommandToken>
    {

        public RootCommand(string commandName) :base(commandName)
        {
        }

        public override string Help => "root";

        public override object ExecuteCommand(RootCommandToken input, CommandManager mgr)
        {
            CommandManager cmdMgr = new CommandManager(input.InitialData);
            cmdMgr.Commands.AddRange(mgr.Commands);

            int arg = 0;
            string[] args = input.Args;
            while (arg < args.Length)
            {
                Command curr = cmdMgr.PeekComand(args[arg]);
                cmdMgr.Execute(args[arg++], args.SubArray(arg));
                arg += curr.Signeture.ArgsParsed;
            }

            return cmdMgr.CurrentData;
        }
    }
}
