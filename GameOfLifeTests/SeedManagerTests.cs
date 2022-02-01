using System.Collections.Generic;
using System.Linq;
using GameOfLife;
using GameOfLife.Input;
using GameOfLife.Output;
using GameOfLife.SeedSaver;
using Xunit;

namespace GameOfLifeTests
{
    public class SeedManagerTests
    {
        private string _testFilePath;

        public SeedManagerTests()
        {
            _testFilePath = "../../../../GameOfLife/TestSavedSeedsJsonFile.json";
        }
        
        [Fact]
        public void given_InputEqualsFiveAndSix_when_GetSeedGeneration_then_seedGenerationWidthAndHeightEqualsFiveAndSix()
        {
            IUserInput mockInput = new TestInput(new List<string>()
            {
                Constants.NoResponse,
                "5",
                "6",
                Constants.FinishedSelecting
            });

            SeedManager seedManager = new SeedManager(mockInput, new ConsoleOutput(), _testFilePath);

            GenerationInfo seedGeneration = seedManager.GetSeedGeneration();
            
            Assert.Equal(5, seedGeneration.Width);
            Assert.Equal(6, seedGeneration.Height);
        }
        
        [Fact]
        public void given_UserSelectsCellNumberTwo_when_GetSeedGeneration_then_seedGenerationLivingCellsContainsTwo()
        {
            IUserInput mockInput = new TestInput(new List<string>()
            {
                Constants.NoResponse,
                "5",
                "6",
                Constants.Right,
                Constants.SelectDeselect,
                Constants.FinishedSelecting
            });

            SeedManager seedManager = new SeedManager(mockInput, new ConsoleOutput(), _testFilePath);

            GenerationInfo seedGeneration = seedManager.GetSeedGeneration();
            
            Assert.Contains(seedGeneration.LivingCells, position => position.Number == 2);
        }
        
        [Fact]
        public void given_UserWantsToLoadFirstSeed_when_GetSeedGeneration_then_return_GenerationInfoFromFirstSeed()
        {
            IUserInput mockInput = new TestInput(new List<string>()
            {
                Constants.YesResponse,
                "0",
            });
        
            SeedManager seedManager = new SeedManager(mockInput, new ConsoleOutput(), _testFilePath);
        
            GenerationInfo seedGeneration = seedManager.GetSeedGeneration();
            
            Assert.Equal(38, seedGeneration.Width);
            Assert.Equal(50, seedGeneration.Height);
            Assert.Equal(36, seedGeneration.LivingCells.Count);
        }
        
        [Fact]
        public void given_SeedIsInJsonFile_when_CheckIfSeedIsAlreadySaved_then_return_true()
        {
            IUserInput mockInput = new TestInput(new List<string>());
        
            SeedManager seedManager = new SeedManager(mockInput, new ConsoleOutput(), _testFilePath);

            GenerationInfo mockSeed = new GenerationInfo(4, 4, new List<CellPosition>()
            {
                new CellPosition(10)
            });
        
            Assert.True(seedManager.CheckIfSeedIsAlreadySaved(mockSeed));
        }
        
        [Fact]
        public void given_SeedIsNotInJsonFile_when_CheckIfSeedIsAlreadySaved_then_return_false()
        {
            IUserInput mockInput = new TestInput(new List<string>());
        
            SeedManager seedManager = new SeedManager(mockInput, new ConsoleOutput(), _testFilePath);

            GenerationInfo mockSeed = new GenerationInfo(4, 4, new List<CellPosition>()
            {
                new CellPosition(10),
                new CellPosition(11)
            });
        
            Assert.False(seedManager.CheckIfSeedIsAlreadySaved(mockSeed));
        }
        
        [Fact]
        public void given_SeedNameEqualsTest_SaveSeed_then_SeedWithNameTestIsInJsonFile()
        {
            ISeedSaver seedSaver = new JSONSeedSaver(_testFilePath);
            List<GenerationInfo> defaultSeeds = seedSaver.LoadSavedSeeds();

            IUserInput mockInput = new TestInput(new List<string>()
            {
                "test"
            });
        
            SeedManager seedManager = new SeedManager(mockInput, new ConsoleOutput(), _testFilePath);
        
            GenerationInfo mockSeed = new GenerationInfo(4, 4, new List<CellPosition>());
        
            seedManager.SaveSeed(mockSeed);
            List<GenerationInfo> newSeeds = seedSaver.LoadSavedSeeds();

            Assert.Equal("test", newSeeds.Last().Name);
            
            seedSaver.SaveSeeds(defaultSeeds);
        }
    }
}