using System;
using System.IO;

namespace ToDo
{
    public class RemoveCommand : Command
    {
        public override bool Validate(string[] args)
        {
            switch (args.Length)
            {
                case 1:
                    Console.WriteLine("Unable to remove: no index provided");
                    return false;

                case 2:
                    if (!int.TryParse(args[1], out _))
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
            string[] lines = File.ReadAllLines(taskFile);

            int num = int.Parse(args[1]);


            if (lines.Length >= num)
            {
                lines[num - 1] = null;
                string[] newList = new string[lines.Length - 1];
                int j = 0;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (!String.IsNullOrEmpty(lines[i]))
                    {
                        newList[j] = lines[i];
                        j++;
                    }
                }

                File.WriteAllLines(taskFile, newList);
            }
            else
            {
                Console.WriteLine("Unable to remove: index is out of bound");
            }
        }
    }
}