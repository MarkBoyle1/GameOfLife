using System.Collections.Generic;
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
            _input = new TestInput(new List<string>());
            _seedGenerator = new ManualSelection(_input);
        }
        
        [Fact]
        public void given_ActiveCellEqualsOne_and_InputEqualsRight_when_MoveActiveCell_then_return_Two()
        {
            _input = new TestInput(new List<string>(){Constants.Right});
            _seedGenerator = new ManualSelection(_input);
            
            int activeCell = 1;

            activeCell = _seedGenerator.MoveActiveCell(activeCell, 5);
            
            Assert.Equal(2, activeCell);
        }
        
        [Fact]
        public void given_ActiveCellEqualsFour_and_InputEqualsLeft_when_MoveActiveCell_then_return_Three()
        {
            _input = new TestInput(new List<string>(){Constants.Left});
            _seedGenerator = new ManualSelection(_input);
            
            int activeCell = 4;

            activeCell = _seedGenerator.MoveActiveCell(activeCell, 5);
            
            Assert.Equal(3, activeCell);
        }
        
        [Fact]
        public void given_ActiveCellEqualsFour_and_WidthEqualsFive_and_InputEqualsDown_when_MoveActiveCell_then_return_Nine()
        {
            _input = new TestInput(new List<string>(){Constants.Down});
            _seedGenerator = new ManualSelection(_input);
            
            int activeCell = 4;

            activeCell = _seedGenerator.MoveActiveCell(activeCell, 5);
            
            Assert.Equal(9, activeCell);
        }
        
        [Fact]
        public void given_ActiveCellEqualsEleven_and_WidthEqualsFive_and_InputEqualsUp_when_MoveActiveCell_then_return_Six()
        {
            _input = new TestInput(new List<string>(){Constants.Up});
            _seedGenerator = new ManualSelection(_input);
            
            int activeCell = 11;

            activeCell = _seedGenerator.MoveActiveCell(activeCell, 5);
            
            Assert.Equal(6, activeCell);
        }
    }
}