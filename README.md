# CommandManager

used [here](https://github.com/AnatolyRybchych/sdecl/tree/main)

## Example
> User.cs
```CS
public class User
{
    public Name { get; private set; )
    public User(string name)
    {
        Name = name;
    }
}
```
> TestCommand.cs
```CS
public class TestCommand: CommandWithTypeOrDerivative<User>
{
     public StringCommandArgument Target { get; private set; }
     public override string Help => "seys hello to <target>";
     
     public TestCommand()
     {
         Target = new StringCommandArgument(true, "target", ".+");
         Signeture.Args.Add(Target);
     }
     
     public override object ExecuteCommand(User input, CommandManager.CommandManager mgr)
     {
         return $"message {Target.Value} to {input.Name}";
     }
}
```
> Main.cs
```CS
static void Main(string[] args)
{
    CommandManager.CommandManager commandManager = new CommandManager.CommandManager(new RootCommandToken(args, new User("World")));

    commandManager.Commands.Add(new CommandsCommand("commands"));//for all objects returns commands list with arguments and help to current type
    commandManager.Commands.Add(new IEnumerableAtCommand("at"));//for Type:IEnumerable<object> returns element at index  
    commandManager.Commands.Add(new TestCommand("say"));//for Type:IEnumerable<object> returns element at index  
    commandManager.Commands.Add(new RootCommand("start"));//root command

    commandManager.Execute("start", args);
    Console.WriteLine(new CommandResonseSerializer().Serialize(commandManager.CurrentData));
}
```
> Result
```Shell
$ test.exe say Hello,
message Hello, to World
```
