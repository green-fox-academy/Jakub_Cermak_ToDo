namespace ToDo
{
    public abstract class Command
    {
        public string[] Arg { get; set; }

        public abstract bool Validate(string[] args);
        public abstract void Execute(string[] args, string taskFile);
    }
}