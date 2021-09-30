using System;
using System.Collections.Generic;


namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            string taskFile = "Tasks.txt";

            AddCommand a = new AddCommand();
            RemoveCommand r = new RemoveCommand();
            ListCommand l = new ListCommand();
            CompleteCommand c = new CompleteCommand();

            Dictionary<string, Command> arguments = new Dictionary<string, Command>()
            {
                {"-a", a}, {"-r", r}, {"-l",l}, {"-c",c}
            };

            if (args.Length != 0)
            {
                GetSwitch(arguments, args, taskFile);
            }
        }

        public static void GetSwitch(Dictionary<String, Command> switchers, string[] args, string path)
        {
            Command switcher = switchers[args[0]];
            if (switcher.Validate(args))
            {
                switcher.Execute(args, path);
            }
        }
    }
}