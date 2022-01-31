using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GameOfLife.SeedSaver
{
    public class JSONSeedSaver : ISeedSaver
    {
        private readonly string _filePath;

        public JSONSeedSaver(string filePath)
        {
            _filePath = filePath;
        }
        public List<GenerationInfo> LoadSavedSeeds()
        {
            string jsonString = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<GenerationInfo>>(jsonString);
        }

        public void SaveSeeds(List<GenerationInfo> seeds)
        {
            string savedSeedJsonString = JsonSerializer.Serialize(seeds);
            File.WriteAllTextAsync(_filePath, savedSeedJsonString);
        }
    }
}