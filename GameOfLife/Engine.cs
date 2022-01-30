
using GameOfLife.Input;

namespace GameOfLife
{
    public class Engine
    {
        private IOutput _output;
        private SeedManager _seedManager;
        private GenerationUpdater _generationUpdater;
        private GridBuilder _gridBuilder;
        private GameManager _gameManager;
        
        public Engine(IUserInput input, IOutput output)
        {
            _output = output;
            _gameManager = new GameManager(output);
            _generationUpdater = new GenerationUpdater();
            _gridBuilder = new GridBuilder();
            _seedManager = new SeedManager(input, output);
        }
        
        public void RunProgram()
        {
            GenerationInfo nextGeneration;
            _output.DisplayMessage(OutputMessages.Welcome);
            
            GenerationInfo seedGeneration = _seedManager.GetSeedGeneration();
            Grid grid = _gridBuilder.CreateGrid(seedGeneration);
            _output.DisplayGrid(grid);
            
            do
            {
                nextGeneration = _generationUpdater.GetNextGeneration(grid);
                grid = _gridBuilder.CreateGrid(nextGeneration);
                _output.DisplayGrid(grid);
            }
            while (!_gameManager.CheckForGameFinish(nextGeneration));

            bool seedAlreadySaved = _seedManager.CheckIfSeedIsAlreadySaved(seedGeneration);

            if (!seedAlreadySaved)
            {
                _seedManager.SaveSeedIfRequested(seedGeneration);
            }
        }
    }
}