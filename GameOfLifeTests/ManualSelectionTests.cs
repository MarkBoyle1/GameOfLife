using System.Collections.Generic;
using GameOfLife;
using GameOfLife.Input;
using GameOfLife.Output;
using GameOfLife.SeedGenerator;
using Xunit;

namespace GameOfLifeTests
{
    public class ManualSelectionTests
    {
        [Fact]
        public void
            given_ActiveCellEqualsOne_and_InputEqualsSelectDeselect_when_GetPositionsOfLivingCells_then_return_ListContainingOne()
        {
            IUserInput mockInput = new TestInput(new List<string>()
            {
                Constants.SelectDeselect,
                Constants.FinishedSelecting
            });
            ISeedGenerator seedGenerator = new ManualSelection(mockInput, new ConsoleOutput());

            List<CellPosition> livingCells = seedGenerator.GetPositionsOfLivingCells(5, 5);
            
            Assert.Contains(livingCells, cellPosition => cellPosition.Number == 1);
        }
        
        [Fact]
        public void
            given_ActiveCellMovesTwoPlacesToTheRightThenSelectsIt_when_GetPositionsOfLivingCells_then_return_ListContainingThree()
        {
            IUserInput mockInput = new TestInput(new List<string>()
            {
                Constants.Right, 
                Constants.Right, 
                Constants.SelectDeselect, 
                Constants.FinishedSelecting
            });
            ISeedGenerator seedGenerator = new ManualSelection(mockInput, new ConsoleOutput());

            List<CellPosition> livingCells = seedGenerator.GetPositionsOfLivingCells(5, 5);
            
            Assert.Contains(livingCells, cellPosition => cellPosition.Number == 3);
        }
        
        [Fact]
        public void
            given_ActiveCellIsDeselected_when_GetPositionsOfLivingCells_then_return_EmptyList()
        {
            IUserInput mockInput = new TestInput(new List<string>()
            {
                Constants.SelectDeselect,
                Constants.SelectDeselect, 
                Constants.FinishedSelecting
            });
            ISeedGenerator seedGenerator = new ManualSelection(mockInput, new ConsoleOutput());

            List<CellPosition> livingCells = seedGenerator.GetPositionsOfLivingCells(5, 5);
            
            Assert.Empty(livingCells);
        }
        
        [Fact]
        public void
            given_TwoCellsAreSelected_when_GetPositionsOfLivingCells_then_return_ListContainingTwoValues()
        {
            IUserInput mockInput = new TestInput(new List<string>()
            {
                Constants.SelectDeselect,
                Constants.Right,
                Constants.SelectDeselect,
                Constants.FinishedSelecting
            });
            ISeedGenerator seedGenerator = new ManualSelection(mockInput, new ConsoleOutput());

            List<CellPosition> livingCells = seedGenerator.GetPositionsOfLivingCells(5, 5);
            
            Assert.Equal(2, livingCells.Count);
        }
        
        [Fact]
        public void
            given_ActiveCellEqualsOne_and_InputEqualsLeft_and_GridWidthEqualsFive_when_GetPositionsOfLivingCells_then_return_ListContainingFive()
        {
            IUserInput mockInput = new TestInput(new List<string>()
            {
                Constants.Left,
                Constants.SelectDeselect,
                Constants.FinishedSelecting
            });
            ISeedGenerator seedGenerator = new ManualSelection(mockInput, new ConsoleOutput());

            List<CellPosition> livingCells = seedGenerator.GetPositionsOfLivingCells(5, 5);
            
            Assert.Contains(livingCells, cellPosition => cellPosition.Number == 5);
        }
        
        [Fact]
        public void
            given_ActiveCellEqualsOne_and_InputEqualsUp_and_GridWidthEqualsFive_when_GetPositionsOfLivingCells_then_return_ListContaining21()
        {
            IUserInput mockInput = new TestInput(new List<string>()
            {
                Constants.Up,
                Constants.SelectDeselect,
                Constants.FinishedSelecting
            });
            ISeedGenerator seedGenerator = new ManualSelection(mockInput, new ConsoleOutput());

            List<CellPosition> livingCells = seedGenerator.GetPositionsOfLivingCells(5, 5);
            
            Assert.Contains(livingCells, cellPosition => cellPosition.Number == 21);
        }
    }
}