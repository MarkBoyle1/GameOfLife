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
        public int MoveActiveCell(int activeCell, int width)
        {
            string input = _input.GetUserInput();
            
            switch (input)
            {
                case Constants.Left:
                    activeCell--;
                    break;
                case Constants.Right:
                    activeCell++;
                    break;
                case Constants.Up:
                    activeCell = activeCell - width;
                    break;
                case Constants.Down:
                    activeCell += width;
                    break;
            }

            return activeCell;
        }
    }
}