
namespace CommandManager
{
    internal class IntCommandArgument : TypedCommandArgument<int>
    {
        public int MaxValue { get; private set; }
        public int MinValue { get; private set; }

        public IntCommandArgument(bool required, string name, int minValue = int.MinValue, int maxValue = int.MaxValue) : base(required, name)
        {
            MaxValue = maxValue;
            MinValue = minValue;
        }

        public override object FromString(string arg) => int.Parse(arg);

        protected override bool IsSatisfies(string args)
        {
            int val;
            return int.TryParse(args, out val) && val >= MinValue && val <= MaxValue;
        }
    }
}
