using CommandPattern.Core.Contracts;


namespace CommandPattern.Core.Commands
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            string res = $"Hello, {args[0]}";
            return res;
        }
    }
}
