namespace ToDo
{
    public class Todo
    {
        public bool Completed { get; private set; }
        public string Name { get; }

        public Todo(string name)
        {
            Completed = false;
            Name = name;
        }

        public Todo(bool completed, string name)
        {
            Completed = completed;
            Name = name;
        }

        public Todo()
        {
            
        }

        public static Todo ConvertLineToObject(string line)
        {
            string[] splitedString = line.Split("  ");
            bool completed = splitedString[0].ToLower() == "true"; 
            return new Todo(completed, splitedString[1]);
        }

        public void SwitchCompetition()
        {
           Completed = !Completed;
        }

        public string ToString(bool toFile)
        {
            return $"{Completed}  {Name}";
        }

        public override string ToString()
        {
            return (Completed ? "[X]":"[ ]") + " - " + Name;
        }
    }
}