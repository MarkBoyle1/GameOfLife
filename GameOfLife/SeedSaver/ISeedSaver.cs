
using System.Collections.Generic;

namespace GameOfLife.SeedSaver
{
    public interface ISeedSaver
    {
        public List<GenerationInfo> LoadSavedSeeds();
        public void SaveSeeds(List<GenerationInfo> seeds);
    }
}