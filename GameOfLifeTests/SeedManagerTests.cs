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
        public void given_ActiveCellEqualsOne_and_InputEqualsRight_when_MoveActiveCell_then_return_Two()
        {
            _input = new TestInput(new List<string>(){Constants.Right});
            _seedGenerator = new ManualSelection(_input, new ConsoleOutput());
            
            int activeCell = 1;

            activeCell = _seedGenerator.MoveActiveCell(activeCell, 5, 5);
            
            Assert.Equal(2, activeCell);
        }
        
        [Fact]
        public void given_ActiveCellEqualsFour_and_InputEqualsLeft_when_MoveActiveCell_then_return_Three()
        {
            _input = new TestInput(new List<string>(){Constants.Left});
            _seedGenerator = new ManualSelection(_input, new ConsoleOutput());
            
            int activeCell = 4;

            activeCell = _seedGenerator.MoveActiveCell(activeCell, 5, 5);
            
            Assert.Equal(3, activeCell);
        }
        
        [Fact]
        public void given_ActiveCellEqualsOne_and_GridHeightAndWidthEqualFive_and_InputEqualsUp_when_MoveActiveCell_then_return_21()
        {
            _input = new TestInput(new List<string>(){Constants.Up});
            _seedGenerator = new ManualSelection(_input, new ConsoleOutput());
            
            int activeCell = 1;

            activeCell = _seedGenerator.MoveActiveCell(activeCell, 5, 5);
            
            Assert.Equal(21, activeCell);
        }
        
        [Fact]
        public void given_ActiveCellEqualsOne_and_GridHeightAndWidthEqualFive_and_InputEqualsLeft_when_MoveActiveCell_then_return_Five()
        {
            _input = new TestInput(new List<string>(){Constants.Left});
            _seedGenerator = new ManualSelection(_input, new ConsoleOutput());
            
            int activeCell = 1;

            activeCell = _seedGenerator.MoveActiveCell(activeCell, 5, 5);
            
            Assert.Equal(5, activeCell);
        }
        
        [Fact]
        public void given_ActiveCellEqualsFour_and_GridHeightAndWidthEqualsFive_and_InputEqualsDown_when_MoveActiveCell_then_return_Nine()
        {
            _input = new TestInput(new List<string>(){Constants.Down});
            _seedGenerator = new ManualSelection(_input, new ConsoleOutput());
            
            int activeCell = 4;

            activeCell = _seedGenerator.MoveActiveCell(activeCell, 5, 5);
            
            Assert.Equal(9, activeCell);
        }
        
        [Fact]
        public void given_ActiveCellEqualsFive_and_GridHeightAndWidthEqualsFive_and_InputEqualsRight_when_MoveActiveCell_then_return_One()
        {
            _input = new TestInput(new List<string>(){Constants.Right});
            _seedGenerator = new ManualSelection(_input, new ConsoleOutput());
            
            int activeCell = 5;

            activeCell = _seedGenerator.MoveActiveCell(activeCell, 5, 5);
            
            Assert.Equal(1, activeCell);
        }
        
        [Fact]
        public void given_ActiveCellEquals21_and_GridHeightAndWidthEqualsFive_and_InputEqualsRight_when_MoveActiveCell_then_return_One()
        {
            _input = new TestInput(new List<string>(){Constants.Down});
            _seedGenerator = new ManualSelection(_input, new ConsoleOutput());
            
            int activeCell = 21;

            activeCell = _seedGenerator.MoveActiveCell(activeCell, 5, 5);
            
            Assert.Equal(1, activeCell);
        }
        
        [Fact]
        public void given_ActiveCellEqualsEleven_and_WidthEqualsFive_and_InputEqualsUp_when_MoveActiveCell_then_return_Six()
        {
            _input = new TestInput(new List<string>(){Constants.Up});
            _seedGenerator = new ManualSelection(_input, new ConsoleOutput());
            
            int activeCell = 11;

            activeCell = _seedGenerator.MoveActiveCell(activeCell, 5, 5);
            
            Assert.Equal(6, activeCell);
        }

        [Fact]
        public void
            given_ActiveCellEqualsOne_and_InputEqualsSelectDeselect_when_GetPositionsOfLivingCells_then_return_ListContainingOne()
        {
            _input = new TestInput(new List<string>()
            {
                Constants.SelectDeselect,
                Constants.FinishedSelecting
            });
            _seedGenerator = new ManualSelection(_input, new ConsoleOutput());

            List<CellPosition> livingCells = _seedGenerator.GetPositionsOfLivingCells(5, 5);
            
            Assert.Contains(livingCells, cellPosition => cellPosition.Number == 1);
        }
        
        [Fact]
        public void
            given_ActiveCellMovesTwoPlacesToTheRightThenSelectsIt_when_GetPositionsOfLivingCells_then_return_ListContainingThree()
        {
            _input = new TestInput(new List<string>()
            {
                Constants.Right, 
                Constants.Right, 
                Constants.SelectDeselect, 
                Constants.FinishedSelecting
            });
            _seedGenerator = new ManualSelection(_input, new ConsoleOutput());

            List<CellPosition> livingCells = _seedGenerator.GetPositionsOfLivingCells(5, 5);
            
            Assert.Contains(livingCells, cellPosition => cellPosition.Number == 3);
        }
        
        [Fact]
        public void
            given_ActiveCellIsDeselected_when_GetPositionsOfLivingCells_then_return_EmptyList()
        {
            _input = new TestInput(new List<string>()
            {
                Constants.SelectDeselect,
                Constants.SelectDeselect, 
                Constants.FinishedSelecting
            });
            _seedGenerator = new ManualSelection(_input, new ConsoleOutput());

            List<CellPosition> livingCells = _seedGenerator.GetPositionsOfLivingCells(5, 5);
            
            Assert.Empty(livingCells);
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
    }
}