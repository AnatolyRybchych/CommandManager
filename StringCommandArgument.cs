using System.Text.RegularExpressions;

namespace CommandManager
{
    public class StringCommandArgument : TypedCommandArgument<string>
    {
        Regex satisfyingRegex;

        public StringCommandArgument(bool required, string name, string satisfyingRegex = ".*") : base(required, name) => this.satisfyingRegex = new Regex(satisfyingRegex);

        public override object FromString(string arg) => arg;
        protected override bool IsSatisfies(string args) => satisfyingRegex.IsMatch(args);
    }
}
