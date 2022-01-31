using System.Collections.Generic;
using GameOfLife;
using GameOfLife.SeedGenerator;
using Xunit;

namespace GameOfLifeTests
{
    public class PreLoadedSelectionTests
    {
        [Fact]
        public void given_SavedSeedWidthEqualsFive_when_GetGridWidth_then_return_Five()
        {
            GenerationInfo mockSeed = new GenerationInfo(5, 10, new List<CellPosition>());
            ISeedGenerator seedGenerator = new PreLoadedSelection(mockSeed);

            int width = seedGenerator.GetGridWidth();
            
            Assert.Equal(5, width);
        }
        
        [Fact]
        public void given_SavedSeedHeightEqualsTen_when_GetGridHeight_then_return_Ten()
        {
            GenerationInfo mockSeed =  new GenerationInfo(5, 10, new List<CellPosition>());
            ISeedGenerator seedGenerator = new PreLoadedSelection(mockSeed);

            int height = seedGenerator.GetGridHeight();
            
            Assert.Equal(10, height);
        }
        
        [Fact]
        public void given_SavedSeedContainsLivingCellAtPositionThree_when_GetPositionsOfLivingCells_then_return_ListContaingThree()
        {
            GenerationInfo mockSeed = new GenerationInfo(5, 10, new List<CellPosition>() {new CellPosition(3)});
            ISeedGenerator seedGenerator = new PreLoadedSelection(mockSeed);

            List<CellPosition> livingCells = seedGenerator.GetPositionsOfLivingCells(5,10);
            
            Assert.Contains(livingCells, cellPosition => cellPosition.Number == 3);
        }
    }
}