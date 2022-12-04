namespace AutosplitGenerator
{
    public class Map
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public LevelType LevelType { get; set; }

        public Map(string name, string path, LevelType levelType)
        {
            Name = name;
            Path = path;
            LevelType = levelType;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
