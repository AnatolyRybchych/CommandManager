
namespace CommandManager
{
    public abstract class TypedCommandArgument<T> : CommandArgument
    {
        public TypedCommandArgument(bool required, string name) : base(required, name)
        {
        }

        public override Type Type => typeof(T);

        public virtual T? Value => ObjValue == null ? default(T) : (T?)ObjValue;
    }
}
