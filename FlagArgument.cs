
namespace CommandManager
{
    public class FlagArgument : TypedCommandArgument<bool>
    {
        public string FlagName { get; private set; }

        public FlagArgument(string name, string flag) : base(false, name)
        {
            FlagName = flag;
        }

        public override object FromString(string arg)
        {
            return arg == FlagName;
        }

        protected override bool IsSatisfies(string arg)
        {
            return arg == FlagName;
        }
    }
}
