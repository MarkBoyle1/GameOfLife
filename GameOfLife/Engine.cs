
using GameOfLife.Input;
using GameOfLife.Output;

namespace GameOfLife
{
    public class Engine
    {
        private readonly IOutput _output;
        private readonly SeedManager _seedManager;
        private readonly GenerationUpdater _generationUpdater;
        private readonly GridBuilder _gridBuilder;
        private readonly GameManager _gameManager;
        
        public Engine(IUserInput input, IOutput output)
        {
            _output = output;
            _gameManager = new GameManager(output);
            _generationUpdater = new GenerationUpdater();
            _gridBuilder = new GridBuilder();
            _seedManager = new SeedManager(input, output);
        }
        
        public GenerationInfo RunProgram()
        {
            GenerationInfo nextGeneration;
            _output.DisplayMessage(OutputMessages.Welcome);
            
            GenerationInfo seedGeneration = _seedManager.GetSeedGeneration();
            Grid grid = _gridBuilder.CreateGrid(seedGeneration);
            _output.DisplayGrid(grid, Constants.TimeToDisplaySeedInMilliseconds);
            
            do
            {
                nextGeneration = _generationUpdater.GetNextGeneration(grid);
                grid = _gridBuilder.CreateGrid(nextGeneration);
                _output.DisplayGrid(grid);
            }
            while (!_gameManager.CheckForGameFinish(nextGeneration));

            bool seedAlreadySaved = _seedManager.CheckIfSeedIsAlreadySaved(seedGeneration);

            if (!seedAlreadySaved && _seedManager.CheckIfUserWantsToSaveTheSeed())
            {
                _seedManager.SaveSeed(seedGeneration);
            }

            return nextGeneration;
        }
    }
}