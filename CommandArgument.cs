
namespace CommandManager
{
    internal abstract class CommandArgument
    {
        public delegate bool IsSatisfiesDelegate(string arg);

        public bool IsRequired { get; private set; }
        public string Name { get; private set; }
        public object? ObjValue { get; private set; }
        

        public CommandArgument(bool required, string name)
        {
            IsRequired = required;
            Name = name;   
        }

        public void Set(string arg)
        {
            if(IsSatisfies(arg))
                ObjValue = FromString(arg);
            else
            {
                if (IsRequired) throw new Exception($"cannot parse argument {this} from string \"{arg}\"");
                else ObjValue = null;
            }
        }

        public override string ToString() => $"{this.Type.Name}:{Name}";

        public abstract Type Type { get; }

        protected abstract bool IsSatisfies(string args);
        public abstract object FromString(string arg);
    }
}
