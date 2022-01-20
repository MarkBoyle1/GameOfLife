using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using GameOfLife.Input;

namespace GameOfLife
{
    public class SeedManager
    {
        private IUserInput _input;
        private IOutput _output;
        private ISeedSaver _seedSaver;
        private List<SavedSeed> _savedSeeds;

        public SeedManager(IUserInput input, IOutput output, string filePath = Constants.JSONSavedSeedsFilePath)
        {
            _input = input;
            _output = output;
            _seedSaver = new JSONSeedSaver(filePath);
            _savedSeeds = _seedSaver.LoadSavedSeeds();
        }
        
        public GenerationInfo GetSeedGeneration()
        {
            ISeedGenerator seedGenerator;

            bool userWantsToLoadSavedSeed = CheckIfUserWantsToUseASavedSeed();

            if (userWantsToLoadSavedSeed)
            {
                SavedSeed savedSeed = ChooseSavedSeed(_savedSeeds);
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

        private SavedSeed ChooseSavedSeed(List<SavedSeed> savedSeeds)
        {
            _output.DisplayMessage(OutputMessages.SavedSeedSelection);
            
            for (int seedNumber = 0; seedNumber < savedSeeds.Count; seedNumber++)
            {
                _output.DisplayMessage(seedNumber + " - " + savedSeeds[seedNumber].Name);
            }

            string response = _input.GetUserInput();
            int selectedSeedNumber = Convert.ToInt16(response);

            return savedSeeds[selectedSeedNumber];
        }
        public void SaveSeedIfRequested(GenerationInfo seedGeneration)
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
        
                SavedSeed newSeed = new SavedSeed(name, seedGeneration);
                _savedSeeds.Add(newSeed);
            }
                
            _seedSaver.SaveSeeds(_savedSeeds);
        }
    }
}