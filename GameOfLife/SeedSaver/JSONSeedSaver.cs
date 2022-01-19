using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GameOfLife
{
    public class JSONSeedSaver : ISeedSaver
    {
        public List<SavedSeed> LoadSavedSeeds()
        {
            string jsonString = File.ReadAllText(Constants.JSONSavedSeedsFilePath);
            return JsonSerializer.Deserialize<List<SavedSeed>>(jsonString);
        }

        public void SaveSeeds(List<SavedSeed> seeds)
        {
            string savedSeedJsonString = JsonSerializer.Serialize(seeds);
            File.WriteAllTextAsync(Constants.JSONSavedSeedsFilePath, savedSeedJsonString);
        }
    }
}