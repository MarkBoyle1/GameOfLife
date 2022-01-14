using GameOfLife;
using GameOfLife.Input;
using Xunit;

namespace GameOfLifeTests
{
    public class SetUpTests
    {
        private IUserInput _input;
        private ISeedGenerator _seedGenerator;

        public SetUpTests()
        {
            _input = new TestInput();
            _seedGenerator = new ManualSelection(_input);
        }
        [Fact]
        public void given_ActiveCellEqualsOne_and_InputEqualsRight_when_MoveActiveCell_then_return_Two()
        {
            int activeCell = 1;

            activeCell = _seedGenerator.MoveActiveCell(activeCell);
            
            Assert.Equal(2, activeCell);
        }
    }
}