using System;
using System.IO;


namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] startupMessage = File.ReadAllLines("startupMessage.txt");

            if (args.Length == 0)
            {
                foreach (var line in startupMessage)
                {
                    Console.WriteLine(line);
                }
            }

            Console.WriteLine();

            if (args.Length > 0)
            {
                SwitchArgument(args[0]);
            }
            else
            {
                string userInput = "";
                do
                {
                    userInput = Console.ReadLine();
                    SwitchArgument(userInput);
                } while (userInput != "-q");
            }
        }

        public static void SwitchArgument(string argument)
        {
            Todos todos = new Todos();

            switch (argument)
            {
                case "-l":
                    todos.PrintAllTasks();
                    break;
                case "-a":
                    string task = Console.ReadLine();
                    todos.AddTask(task);
                    break;
                case "-r":
                    todos.RemoveTask(int.Parse("1"));
                    break;
                case "-c":
                    todos.CompleteTask(int.Parse("1"));
                    todos.PrintAllTasks();
                    break;
                default:
                    Console.WriteLine("Try Again.");
                    break;
            }
        }
    }
}