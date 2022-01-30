using System.Collections.Generic;
using GameOfLife;
using GameOfLife.Input;
using Xunit;

namespace GameOfLifeTests
{
    public class GameManagerTests
    {
        [Fact]
        public void given_GenerationHasNoLivingCells_when_CheckForGameFinish_then_return_true()
        {
            GameManager gameManager = new GameManager(new ConsoleOutput());
            GenerationInfo mockGeneration = new GenerationInfo(5, 5, new List<CellPosition>());

            bool gameHasFinished = gameManager.CheckForGameFinish(mockGeneration);
            
            Assert.True(gameHasFinished);
        }
        
        [Fact]
        public void given_GenerationHasLivingCells_when_CheckForGameFinish_then_return_false()
        {
            GameManager gameManager = new GameManager(new ConsoleOutput());
            GenerationInfo mockGeneration = new GenerationInfo(5, 5, new List<CellPosition>()
            {
                new CellPosition(1)
            });

            bool gameHasFinished = gameManager.CheckForGameFinish(mockGeneration);
            
            Assert.False(gameHasFinished);
        }
        
        [Fact]
        public void given_TwoGenerationsInARowAreTheSame_when_CheckForGameFinish_then_return_true()
        {
            GameManager gameManager = new GameManager(new ConsoleOutput());
            GenerationInfo mockGeneration1 = new GenerationInfo(5, 5, new List<CellPosition>()
            {
                new CellPosition(1)
            });
            GenerationInfo mockGeneration2 = new GenerationInfo(5, 5, new List<CellPosition>()
            {
                new CellPosition(1)
            });

            Assert.False(gameManager.CheckForGameFinish(mockGeneration1));
            Assert.True(gameManager.CheckForGameFinish(mockGeneration2));
        }
        
        [Fact]
        public void given_InfiniteLoopDetectedAfterTwoGenerations_when_CheckForGameFinish_then_return_true()
        {
            GameManager gameManager = new GameManager(new ConsoleOutput());
            GenerationInfo mockGeneration1 = new GenerationInfo(5, 5, new List<CellPosition>()
            {
                new CellPosition(1)
            });
            GenerationInfo mockGeneration2 = new GenerationInfo(5, 5, new List<CellPosition>()
            {
                new CellPosition(1),
                new CellPosition(3)
            });
            GenerationInfo mockGeneration3 = new GenerationInfo(5, 5, new List<CellPosition>()
            {
                new CellPosition(1)
            });

            Assert.False(gameManager.CheckForGameFinish(mockGeneration1));
            Assert.False(gameManager.CheckForGameFinish(mockGeneration2));
            Assert.True(gameManager.CheckForGameFinish(mockGeneration3));
        }
        
        [Fact]
        public void given_GenerationLimitEqualsThree_and_ThreeArePlayed_when_CheckForGameFinish_then_return_true()
        {
            GameManager gameManager = new GameManager(new ConsoleOutput(),3);
            GenerationInfo mockGeneration1 = new GenerationInfo(5, 5, new List<CellPosition>()
            {
                new CellPosition(1)
            });
            GenerationInfo mockGeneration2 = new GenerationInfo(5, 5, new List<CellPosition>()
            {
                new CellPosition(1),
                new CellPosition(3)
            });
            GenerationInfo mockGeneration3 = new GenerationInfo(5, 5, new List<CellPosition>()
            {
                new CellPosition(1),
                new CellPosition(2)
            });

            Assert.False(gameManager.CheckForGameFinish(mockGeneration1));
            Assert.False(gameManager.CheckForGameFinish(mockGeneration2));
            Assert.True(gameManager.CheckForGameFinish(mockGeneration3));
        }
    }
}