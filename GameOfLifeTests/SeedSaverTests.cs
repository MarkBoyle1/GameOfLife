using System.Collections.Generic;
using System.Linq;
using GameOfLife;
using GameOfLife.Input;
using Xunit;

namespace GameOfLifeTests
{
    public class SeedSaverTests
    {
        private string _testFilePath;

        public SeedSaverTests()
        {
            _testFilePath = "../../../../GameOfLife/TestSavedSeedsJsonFile.json";
        }
        
        [Fact]
        public void given_JsonFileContainsThreeSeeds_when_LoadSavedSeeds_then_ListOfSavedSeedsCountEqualsThree()
        {
            ISeedSaver seedSaver = new JSONSeedSaver(_testFilePath);

            List<SavedSeed> seeds = seedSaver.LoadSavedSeeds();

            Assert.Equal(3, seeds.Count);
        }
        
        [Fact]
        public void given_FirstSeedOnJsonIsNamedGospersGliderGun_when_LoadSavedSeeds_then_FirstSeedIsNamedGospersGliderGun()
        {
            ISeedSaver seedSaver = new JSONSeedSaver(_testFilePath);

            List<SavedSeed> seeds = seedSaver.LoadSavedSeeds();

            Assert.Equal("GosperGliderGun", seeds.First().Name);
        }
        
        [Fact]
        public void given_JsonFileContainsThreeSeeds_and_ANewSeedIsAdded_when_SaveSeeds_then_JsonFileContainsFourSeeds()
        {
            ISeedSaver seedSaver = new JSONSeedSaver(_testFilePath);

            List<SavedSeed> originalSeeds = seedSaver.LoadSavedSeeds();
            Assert.Equal(3, originalSeeds.Count);

            List<SavedSeed> newSavedSeeds = new List<SavedSeed>(originalSeeds) {};

            SavedSeed newSeed = new SavedSeed("test", new GenerationInfo(5, 5, new List<CellPosition>()));
            newSavedSeeds.Add(newSeed);

            seedSaver.SaveSeeds(newSavedSeeds);
            
            List<SavedSeed> testSeeds = seedSaver.LoadSavedSeeds();
            
            Assert.Equal(4, testSeeds.Count);
            Assert.Equal("test", testSeeds[3].Name);
            
            seedSaver.SaveSeeds(originalSeeds);
        }
    }
}