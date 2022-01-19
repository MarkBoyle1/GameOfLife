using System;
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
        private GameManager _gameManager;
        
        public Engine(IUserInput input, IOutput output)
        {
            _input = input;
            _output = output;
            _gameManager = new GameManager(_input, _output);
            _setUp = new SetUp(_input, _output, _gameManager.LoadSavedSeeds());
            _generationUpdater = new GenerationUpdater();
            _gridBuilder = new GridBuilder();
        }
        
        public void RunProgram()
        {
            GenerationInfo currentGeneration;
            
            GenerationInfo seedGeneration = _setUp.GetSeedGeneration();
            Grid grid = _gridBuilder.CreateGrid(seedGeneration);

            do
            {
                currentGeneration = _generationUpdater.GetNextGeneration(grid);
                grid = _gridBuilder.CreateGrid(currentGeneration);
                _output.DisplayGrid(grid);
            }
            while (!_gameManager.CheckForGameFinish(currentGeneration)) ;

            _gameManager.SaveSeedIfRequested(seedGeneration, _setUp._savedSeeds);
        }
    }
}