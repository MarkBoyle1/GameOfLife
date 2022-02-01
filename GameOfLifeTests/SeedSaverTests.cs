using System.Collections.Generic;
using System.Linq;
using GameOfLife;
using GameOfLife.SeedSaver;
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

            List<GenerationInfo> seeds = seedSaver.LoadSavedSeeds();

            Assert.Equal(5, seeds.Count);
        }
        
        [Fact]
        public void given_FirstSeedOnJsonIsNamedGospersGliderGun_when_LoadSavedSeeds_then_FirstSeedIsNamedGospersGliderGun()
        {
            ISeedSaver seedSaver = new JSONSeedSaver(_testFilePath);

            List<GenerationInfo> seeds = seedSaver.LoadSavedSeeds();

            Assert.Equal("GosperGliderGun", seeds.First().Name);
        }
        
        [Fact]
        public void given_JsonFileContainsThreeSeeds_and_ANewSeedIsAdded_when_SaveSeeds_then_JsonFileContainsFourSeeds()
        {
            ISeedSaver seedSaver = new JSONSeedSaver(_testFilePath);
        
            List<GenerationInfo> originalSeeds = seedSaver.LoadSavedSeeds();
            Assert.Equal(5, originalSeeds.Count);
        
            List<GenerationInfo> newSavedSeeds = new List<GenerationInfo>(originalSeeds) {};
        
            GenerationInfo newSeed = new GenerationInfo(5, 5, new List<CellPosition>());
            newSeed.Name = "test";
            newSavedSeeds.Add(newSeed);
        
            seedSaver.SaveSeeds(newSavedSeeds);
            
            List<GenerationInfo> testSeeds = seedSaver.LoadSavedSeeds();
            
            Assert.Equal(6, testSeeds.Count);
            Assert.Equal("test", testSeeds.Last().Name);
            
            seedSaver.SaveSeeds(originalSeeds);
        }
    }
}