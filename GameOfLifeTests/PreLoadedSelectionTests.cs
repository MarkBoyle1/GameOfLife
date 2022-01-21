using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class PreLoadedSelectionTests
    {
        [Fact]
        public void given_SavedSeedWidthEqualsFive_when_GetGridWidth_then_return_Five()
        {
            SavedSeed savedSeed = new SavedSeed("test", new GenerationInfo(5, 10, new List<CellPosition>()));
            ISeedGenerator seedGenerator = new PreLoadedSelection(savedSeed);

            int width = seedGenerator.GetGridWidth();
            
            Assert.Equal(5, width);
        }
        
        [Fact]
        public void given_SavedSeedHeightEqualsTen_when_GetGridHeight_then_return_Ten()
        {
            SavedSeed savedSeed = new SavedSeed("test", new GenerationInfo(5, 10, new List<CellPosition>()));
            ISeedGenerator seedGenerator = new PreLoadedSelection(savedSeed);

            int height = seedGenerator.GetGridHeight();
            
            Assert.Equal(10, height);
        }
        
        [Fact]
        public void given_SavedSeedContainsLivingCellAtPositionThree_when_GetPositionsOfLivingCells_then_return_ListContaingThree()
        {
            SavedSeed savedSeed = new SavedSeed("test", new GenerationInfo(5, 10, new List<CellPosition>() {new CellPosition(3)}));
            ISeedGenerator seedGenerator = new PreLoadedSelection(savedSeed);

            List<CellPosition> livingCells = seedGenerator.GetPositionsOfLivingCells(5,10);
            
            Assert.Contains(livingCells, cellPosition => cellPosition.Number == 3);
        }
    }
}