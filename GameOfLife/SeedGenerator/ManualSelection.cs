using GameOfLife.Input;

namespace GameOfLife
{
    public class ManualSelection : ISeedGenerator
    {
        private IUserInput _input;
        public ManualSelection(IUserInput input)
        {
            _input = input;
        }
        public int MoveActiveCell(int activeCell)
        {
            return 2;
        }
    }
}