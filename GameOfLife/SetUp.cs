using System.Collections.Generic;
using GameOfLife.Input;

namespace GameOfLife
{
    public class SetUp
    {
        private IUserInput _input;

        public SetUp(IUserInput input)
        {
            _input = input;
        }
        
        public GenerationInfo GetSeedGeneration()
        {
            ISeedGenerator seedGenerator = new ManualSelection(_input, new ConsoleOutput());

            int width = seedGenerator.GetGridWidth();
            int height = seedGenerator.GetGridHeight();

            List<CellPosition> livingCells = seedGenerator.GetPositionsOfLivingCells(width, height);

            return new GenerationInfo(width, height, livingCells);
        }
    }
}