using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Input
{
    public class TestInput : IUserInput
    {
        private readonly List<string> _listOfInputs;

        public TestInput(List<string> listOfInputs)
        {
            _listOfInputs = listOfInputs;
        }
        public string GetUserInput()
        {
            string input = _listOfInputs.First();
            _listOfInputs.RemoveAt(0);

            return input;
        }
    }
}