
namespace CommandManager
{
    public class ArgumentProvider
    {
        public string[] Args { get; private set; }
        private int curr;


        public string CurrentTrace => string.Join(" ", Args.SubArray(0, curr));

        public ArgumentProvider(string[] args)
        {
            Args = args;
            curr = 0;
        }

        public string RequiredNext(string messageIfHaveNot)
        {
            if (curr >= Args.Length) 
                throw new Exception(messageIfHaveNot);
            return Args[curr++];
        }

        public string? VariadicNext() => (curr >= Args.Length) ? null : Args[curr++];
        public void ReturnPrevious() => curr--;
    }
}
