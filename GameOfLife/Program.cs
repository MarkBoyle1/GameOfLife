using GameOfLife.Input;
using GameOfLife.Output;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInput input = new ConsoleInput();
            IOutput output = new ConsoleOutput();

            Engine engine = new Engine(input, output);
            
            engine.RunProgram();
        }
    }
}