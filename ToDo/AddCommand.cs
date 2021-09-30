using System;
using System.IO;

namespace ToDo
{
    public class AddCommand : Command
    {
        public override bool Validate(string[] args)
        {
            if (args.Length is 1 or > 3)
            {
                Console.WriteLine("Unable to add: no or multiple task provided");
                return false;
            }

            return true;
        }

        public override void Execute(string[] args, string taskFile)
        {
            Todo todo = new Todo(args[1]);
            File.AppendAllText(taskFile, todo.ToString(true) + Environment.NewLine);
        }
    }
}