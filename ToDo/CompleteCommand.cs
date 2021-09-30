using System;
using System.IO;

namespace ToDo
{
    public class CompleteCommand: Command
    {
        public override bool Validate(string[] args)
        {
            switch (args.Length)
            {
                case 1:
                    Console.WriteLine("Unable to remove: no index provided");
                    return false;

                case 2:
                    int num;
                    if (!int.TryParse(args[1], out num))
                    {
                        Console.WriteLine("Unable to remove: index is not a number");
                        return false;
                    }

                    return true;

                default:
                    return false;
            }
        }

        public override void Execute(string[] args, string taskFile)
        {
            int number = int.Parse(args[1]);
            string[] lines = File.ReadAllLines(taskFile);
            Todo todo = Todo.ConvertLineToObject(lines[number -1]);
            
            todo.SwitchCompetition();

            lines[number-1] = todo.ToString(true);
            File.WriteAllLines(taskFile,lines);
        }
    }
}