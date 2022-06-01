
namespace CommandManager
{
    public class CommandSignature
    {
        public string CommandName { get; protected set; }
        public List<CommandArgument> Args { get; protected set; }
        public int ArgsParsed { get; private set; }

        public void SendArgs(ArgumentProvider args) 
        {
            ArgsParsed = 0;
            foreach(var arg in Args.Where(arg=>arg.IsRequired))
            {
                arg.Set(args.RequiredNext($"Missing required argument {arg} after {args.CurrentTrace}"));
                ArgsParsed++;
            }

            foreach(var arg in Args.Where(arg => arg.IsRequired == false))
            {
                try
                {
                    string? strArg = args.VariadicNext();
                    if(strArg == null)
                        break;
                    else
                    {
                        arg.Set(strArg);
                        if (arg.ObjValue != null)
                            ArgsParsed++;
                        else
                            break;
                    }
                }
                catch(Exception)
                {
                    args.ReturnPrevious();
                    break;
                }
            }
        }

        public CommandSignature(string commandName)
        {
            ArgsParsed = 0;
            CommandName = commandName;
            Args = new List<CommandArgument>();
        }
    }
}
