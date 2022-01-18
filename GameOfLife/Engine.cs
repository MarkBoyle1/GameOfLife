using GameOfLife.Input;

namespace GameOfLife
{
    public class Engine
    {
        private IUserInput _input;
        private IOutput _output;
        private SetUp _setUp;
        private GenerationUpdater _generationUpdater;
        private GridBuilder _gridBuilder;
        
        public Engine(IUserInput input, IOutput output)
        {
            _input = input;
            _output = output;
            _setUp = new SetUp(_input);
            _generationUpdater = new GenerationUpdater();
            _gridBuilder = new GridBuilder();
        }
        
        public void RunProgram()
        {
            GenerationInfo currentGeneration = _setUp.GetSeedGeneration();
            GameManager gameManager = new GameManager();
            
            while (!gameManager.CheckForGameFinish(currentGeneration))
            {
                Grid grid = _gridBuilder.CreateGrid(currentGeneration);
                _output.DisplayGrid(grid);
                currentGeneration = _generationUpdater.GetNextGeneration(grid);
            }
        }
    }
}