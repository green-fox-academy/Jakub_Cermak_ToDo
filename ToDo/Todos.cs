using System;
using System.IO;


namespace ToDo
{
    public class Todos : Todo
    {
        private string taskFile = "Tasks.txt";

        public void PrintAllTasks()
        {
            string[] cachedFile = File.ReadAllLines(taskFile);
            if (cachedFile.Length != 0)
            {
                for (int i = 0; i < cachedFile.Length; i++)
                {
                    Console.WriteLine(i + 1 +". "+ ReadTask(i));
                    
                }
                Console.WriteLine($"{cachedFile.Length} tasks for today. Keep going.💪");
            }
            else
            {
                Console.WriteLine("No tasks for today. 👍");
            }
        }

        public string ReadTask(int i)
        {
            string[] cachedFile = File.ReadAllLines(taskFile);
            Todo todoObject = ConvertLineToObject(cachedFile[i]);
            return todoObject.ToString();
        }

        public void AddTask(string name)
        {
            Todo todo = new Todo(name);
            File.AppendAllText(taskFile, todo.ToString(true) + Environment.NewLine);
        }

        public void RemoveTask(int number)
        {
            string[] lines = File.ReadAllLines(taskFile);
            lines[number-1] = null;
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

        public void CompleteTask(int number)
        {
            string[] lines = File.ReadAllLines(taskFile);
            Todo todo = Todo.ConvertLineToObject(lines[number -1]);
            
            todo.SwitchCompetition();

            lines[number-1] = todo.ToString(true);
            File.WriteAllLines(taskFile,lines);
        }
    }
}