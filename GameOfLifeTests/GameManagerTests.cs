using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class GameManagerTests
    {
        private GameManager _gameManager = new GameManager();
        
        [Fact]
        public void given_GenerationHasNoLivingCells_when_CheckForGameFinish_then_return_true()
        {
            GameManager gameManager = new GameManager();
            GenerationInfo generation = new GenerationInfo(5, 5, new List<CellPosition>());

            bool gameHasFinished = gameManager.CheckForGameFinish(generation);
            
            Assert.True(gameHasFinished);
        }
        
        [Fact]
        public void given_GenerationHasLivingCells_when_CheckForGameFinish_then_return_false()
        {
            GameManager gameManager = new GameManager();
            GenerationInfo generation = new GenerationInfo(5, 5, new List<CellPosition>()
            {
                new CellPosition(1)
            });

            bool gameHasFinished = gameManager.CheckForGameFinish(generation);
            
            Assert.False(gameHasFinished);
        }
        
        [Fact]
        public void given_TwoGenerationsInARowAreTheSame_when_CheckForGameFinish_then_return_true()
        {
            GameManager gameManager = new GameManager();
            GenerationInfo generation1 = new GenerationInfo(5, 5, new List<CellPosition>()
            {
                new CellPosition(1)
            });
            GenerationInfo generation2 = new GenerationInfo(5, 5, new List<CellPosition>()
            {
                new CellPosition(1)
            });

            Assert.False(gameManager.CheckForGameFinish(generation1));
            Assert.True(gameManager.CheckForGameFinish(generation2));
        }
    }
}