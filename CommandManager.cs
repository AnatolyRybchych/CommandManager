
namespace CommandManager
{
    internal class CommandManager
    {
        public List<Command> Commands { get; private set; }
        public object CurrentData { get; private set; }

        public CommandManager(object initialData)
        {
            CurrentData = initialData;
            Commands = new List<Command>();
        }

        public Command PeekComand(string commandName)
        {
            var Cmds = Commands.Where(cmd => cmd.Signeture.CommandName == commandName);
            if (Cmds.Count() == 0) throw new Exception($"unrecognized command \"{commandName}\"");

            Cmds = Cmds.Where(cmd => cmd.IsTypeForInput(CurrentData.GetType()));

            int count = Cmds.Count();
            if (count == 0)
                throw new Exception($"command \"{commandName}\" cannot be used with type \"{CurrentData.GetType().Name}\"");
            else if (count > 1)
                throw new Exception($"there are \"{count}\" instances of command \"{commandName}({CurrentData.GetType().Name})\"");
            else
                return Cmds.First();
        }

        public void Execute(string name, string[] args)
        {
            var Cmds = Commands.Where(cmd => cmd.Signeture.CommandName == name);
            if (Cmds.Count() == 0) throw new Exception($"unrecognized command \"{name}\"");

            Cmds = Cmds.Where(cmd => cmd.IsTypeForInput(CurrentData.GetType()));

            int count = Cmds.Count();
            if (count == 0)
                throw new Exception($"command \"{name}\" cannot be used with type \"{CurrentData.GetType().Name}\"");
            else if(count > 1)
            {
                throw new Exception($"there are \"{count}\" instances of command \"{name}({CurrentData.GetType().Name})\"");
            }
            else
            {
                var cmd = Cmds.First();
                cmd.Signeture.SendArgs(new ArgumentProvider(args));
                CurrentData = cmd.Execute(CurrentData, this);
            }
        }
    }
}
