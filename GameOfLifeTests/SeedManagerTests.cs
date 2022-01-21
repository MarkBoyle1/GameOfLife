using System.Collections.Generic;
using GameOfLife;
using GameOfLife.Input;
using Xunit;

namespace GameOfLifeTests
{
    public class SeedManagerTests
    {
        private IUserInput _input;
        private ISeedGenerator _seedGenerator;
        private string _testFilePath;

        public SeedManagerTests()
        {
            _input = new TestInput(new List<string>());
            _seedGenerator = new ManualSelection(_input, new ConsoleOutput());
            _testFilePath = "../../../../GameOfLife/TestSavedSeedsJsonFile.json";
        }
        
        [Fact]
        public void given_InputEqualsFiveAndSix_when_GetSeedGeneration_then_seedGenerationWidthAndHeightEqualsFiveAndSix()
        {
            IUserInput input = new TestInput(new List<string>()
            {
                Constants.NoResponse,
                "5",
                "6",
                Constants.FinishedSelecting
            });

            SeedManager seedManager = new SeedManager(input, new ConsoleOutput(), _testFilePath);

            GenerationInfo seedGeneration = seedManager.GetSeedGeneration();
            
            Assert.Equal(5, seedGeneration.Width);
            Assert.Equal(6, seedGeneration.Height);
        }
        
        [Fact]
        public void given_UserSelectsCellNumberTwo_when_GetSeedGeneration_then_seedGenerationLivingCellsContainsTwo()
        {
            IUserInput input = new TestInput(new List<string>()
            {
                Constants.NoResponse,
                "5",
                "6",
                Constants.Right,
                Constants.SelectDeselect,
                Constants.FinishedSelecting
            });

            SeedManager seedManager = new SeedManager(input, new ConsoleOutput(), _testFilePath);

            GenerationInfo seedGeneration = seedManager.GetSeedGeneration();
            
            Assert.Contains(seedGeneration.LivingCells, position => position.Number == 2);
        }
        
        [Fact]
        public void LoadFromSeedStorage()
        {
            IUserInput input = new TestInput(new List<string>()
            {
                Constants.YesResponse,
                "0",
            });

            SeedManager seedManager = new SeedManager(input, new ConsoleOutput(), _testFilePath);

            GenerationInfo seedGeneration = seedManager.GetSeedGeneration();
            
            Assert.Equal(38, seedGeneration.Width);
        }
    }
}