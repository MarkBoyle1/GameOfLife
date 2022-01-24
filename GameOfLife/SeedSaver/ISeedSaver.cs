
using System.Collections.Generic;

namespace GameOfLife
{
    public interface ISeedSaver
    {
        // public List<SavedSeed> LoadSavedSeeds();
        // public void SaveSeeds(List<SavedSeed> seeds);
        
        public List<GenerationInfo> LoadSavedSeeds();
        public void SaveSeeds(List<GenerationInfo> seeds);
    }
}