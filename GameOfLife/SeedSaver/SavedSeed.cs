namespace GameOfLife
{
    public class SavedSeed
    {
        public string Name { get; }
        public GenerationInfo SeedInfo { get; }

        public SavedSeed(string name, GenerationInfo seedInfo)
        {
            Name = name;
            SeedInfo = seedInfo;
        }
    }
}