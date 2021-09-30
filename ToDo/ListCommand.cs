using System;
using System.IO;

namespace ToDo
{
    public class ListCommand: Command
    {
        public override bool Validate(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("This parameter does not have any inputs.");
                return false;
            }
            return true;
        }
        
        public string ReadTask(int i, string taskFile)
        {
            string[] cachedFile = File.ReadAllLines(taskFile);
            Todo todoObject = Todo.ConvertLineToObject(cachedFile[i]);
            return todoObject.ToString();
        }

        public override void Execute(string[] args, string taskFile)
        {
            string[] cachedFile = File.ReadAllLines(taskFile);
            if (cachedFile.Length != 0)
            {
                for (int i = 0; i < cachedFile.Length; i++)
                {
                    Console.WriteLine(i + 1 +". "+ ReadTask(i,taskFile));
                    
                }
                Console.WriteLine($"{cachedFile.Length} tasks for today. Keep going.💪");
            }
            else
            {
                Console.WriteLine("No tasks for today. 👍");
            }
        }
    }
}