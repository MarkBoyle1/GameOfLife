using System.Collections.Generic;
using GameOfLife;
using GameOfLife.Input;
using GameOfLife.Output;
using Xunit;

namespace GameOfLifeTests
{
    public class EngineTests
    {
        [Fact]
        public void given_SeedHasOneCell_when_RunProgram_then_return_GenerationInfoWithNoLivingCells()
        {
            IUserInput mockInput = new TestInput(new List<string>()
            {
                Constants.NoResponse,
                "5",
                "5",
                Constants.SelectDeselect,
                Constants.FinishedSelecting,
                Constants.NoResponse
            });

            Engine engine = new Engine(mockInput, new ConsoleOutput());

            GenerationInfo finalGeneration = engine.RunProgram();
            
            Assert.Empty(finalGeneration.LivingCells);
        }
        
        [Fact]
        public void given_SeedHasFourLivingCellsInASquare_when_RunProgram_then_return_GenerationInfoWithNoChange()
        {
            IUserInput mockInput = new TestInput(new List<string>()
            {
                Constants.NoResponse,
                "5",
                "5",
                Constants.SelectDeselect,
                Constants.Right,
                Constants.SelectDeselect,
                Constants.Down,
                Constants.SelectDeselect,
                Constants.Left,
                Constants.SelectDeselect,
                Constants.FinishedSelecting,
                Constants.NoResponse
            });

            Engine engine = new Engine(mockInput, new ConsoleOutput());

            GenerationInfo finalGeneration = engine.RunProgram();
            
            Assert.Equal(4 , finalGeneration.LivingCells.Count);
            Assert.Contains(finalGeneration.LivingCells, cellPosition => cellPosition.Number == 1);
            Assert.Contains(finalGeneration.LivingCells, cellPosition => cellPosition.Number == 2);
            Assert.Contains(finalGeneration.LivingCells, cellPosition => cellPosition.Number == 6);
            Assert.Contains(finalGeneration.LivingCells, cellPosition => cellPosition.Number == 7);
        }
    }
}