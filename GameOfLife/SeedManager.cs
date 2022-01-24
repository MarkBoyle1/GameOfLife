using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameOfLife.Input;

namespace GameOfLife
{
    public class SeedManager
    {
        private IUserInput _input;
        private IOutput _output;
        private string _filePath;
        private ISeedSaver _seedSaver;
        // private List<SavedSeed> _savedSeeds;
        private List<GenerationInfo> _savedSeeds;

        public SeedManager(IUserInput input, IOutput output, string filePath = Constants.JsonSavedSeedsFilePath)
        {
            _input = input;
            _output = output;
            _filePath = filePath;
        }
        
        public GenerationInfo GetSeedGeneration()
        {
            try
            {
                _seedSaver = new JSONSeedSaver(_filePath);
                _savedSeeds = _seedSaver.LoadSavedSeeds();
            }
            catch (FileNotFoundException)
            {
                _output.DisplayMessage(OutputMessages.NoExternalFileFound);
                // _savedSeeds = new List<SavedSeed>();
                _savedSeeds = new List<GenerationInfo>();

            }
            
            ISeedGenerator seedGenerator;
            bool userWantsToLoadSavedSeed;

            if (_savedSeeds.Count > 0)
            {
                userWantsToLoadSavedSeed = CheckIfUserWantsToUseASavedSeed();
            }
            else
            {
                userWantsToLoadSavedSeed = false;
            }

            if (userWantsToLoadSavedSeed)
            {
                GenerationInfo savedSeed = ChooseSavedSeed(_savedSeeds);
                seedGenerator = new PreLoadedSelection(savedSeed);
            }
            else
            {
                seedGenerator = new ManualSelection(_input, _output);
            }
            
            int width = seedGenerator.GetGridWidth();
            int height = seedGenerator.GetGridHeight();
            List<CellPosition> livingCells = seedGenerator.GetPositionsOfLivingCells(width, height);

            GenerationInfo seedGeneration = new GenerationInfo(width, height, livingCells);

            return seedGeneration;
        }

        private bool CheckIfUserWantsToUseASavedSeed()
        {
            _output.DisplayMessage(OutputMessages.AskIfUserWantsToLoadSavedSeed);
            string response = _input.GetUserInput();

            while (response != Constants.YesResponse && response != Constants.NoResponse)
            {
                _output.DisplayMessage(OutputMessages.InvalidInput);
                response = _input.GetUserInput();
            }

            return response == Constants.YesResponse;
        }

        private GenerationInfo ChooseSavedSeed(List<GenerationInfo> savedSeeds)
        {
            _output.DisplayMessage(OutputMessages.SavedSeedSelection);
            
            for (int seedNumber = 0; seedNumber < savedSeeds.Count; seedNumber++)
            {
                _output.DisplayMessage(seedNumber + " - " + savedSeeds[seedNumber].Name);
            }

            string response = _input.GetUserInput();
            
            List<string> possibleResponses = Enumerable.Range(0, savedSeeds.Count)
                .ToList()
                .ConvertAll(value => value.ToString());

            while(!int.TryParse(response, out int number) || !possibleResponses.Contains(response))
            {
                _output.DisplayMessage(OutputMessages.InvalidInput);
                response = _input.GetUserInput();
            }
            
            int selectedSeedNumber = Convert.ToInt16(response);

            return savedSeeds[selectedSeedNumber];
        }
        public void SaveSeedIfRequested(GenerationInfo seedGeneration)
        {
            if (File.Exists(_filePath))
            {
                _output.DisplayMessage(OutputMessages.WouldYouLikeToSaveTheSeed);
                string response = _input.GetUserInput();
            
                while (response != Constants.YesResponse && response != Constants.NoResponse)
                {
                    _output.DisplayMessage(OutputMessages.InvalidInput);
                    response = _input.GetUserInput();
                }
        
                if (response == Constants.YesResponse)
                {
                    _output.DisplayMessage(OutputMessages.AskForNameOfSavedSeed);
                    string name = _input.GetUserInput();

                    seedGeneration.Name = name;
                    _savedSeeds.Add(seedGeneration);
                    _seedSaver.SaveSeeds(_savedSeeds);

                    // SavedSeed newSeed = new SavedSeed(name, seedGeneration);
                    // _savedSeeds.Add(newSeed);
                    // _seedSaver.SaveSeeds(_savedSeeds);
                }
                
            }
        }

        public bool CheckIfSeedIsAlreadySaved(GenerationInfo seed)
        {
            // int numberOfSameSeeds = _savedSeeds
            //     .Where(savedSeed => savedSeed.SeedInfo.Width == seed.Width)
            //     .Where(savedSeed => savedSeed.SeedInfo.Height == seed.Height)
            //     .Count(savedSeed => Enumerable
            //         .Select<CellPosition, int>(savedSeed.SeedInfo.LivingCells, cell => cell.Number)
            //         .All(seed.LivingCells.Select(cell => cell.Number).Contains));
            
            int numberOfSameSeeds = _savedSeeds
                .Where(savedSeed => savedSeed.Width == seed.Width)
                .Where(savedSeed => savedSeed.Height == seed.Height)
                .Count(savedSeed => Enumerable
                    .Select<CellPosition, int>(savedSeed.LivingCells, cell => cell.Number)
                    .All(seed.LivingCells.Select(cell => cell.Number).Contains));

            return numberOfSameSeeds > 0;
        }
    }
}