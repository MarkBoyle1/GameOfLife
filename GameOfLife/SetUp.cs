using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using GameOfLife.Input;

namespace GameOfLife
{
    public class SetUp
    {
        private IUserInput _input;
        private IOutput _output;
        public List<SavedSeed> _savedSeeds { get; }

        public SetUp(IUserInput input, IOutput output, List<SavedSeed> savedSeeds)
        {
            _input = input;
            _output = output;
            _savedSeeds = savedSeeds;
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
                seedGenerator = new ManualSelection(_input, new ConsoleOutput());
            }
            
            int width = seedGenerator.GetGridWidth();
            int height = seedGenerator.GetGridHeight();

            List<CellPosition> livingCells = seedGenerator.GetPositionsOfLivingCells(width, height);

            GenerationInfo seedGeneration = new GenerationInfo(width, height, livingCells);

            return seedGeneration;
        }

        // public List<SavedSeed> LoadSavedSeeds()
        // {
        //     string jsonString = File.ReadAllText(Constants.JSONSavedSeedsFilePath);
        //     List<SavedSeed> seeds = JsonSerializer.Deserialize<List<SavedSeed>>(jsonString);
        //     return seeds;
        // }

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

        public SavedSeed ChooseSavedSeed(List<SavedSeed> savedSeeds)
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
    }
}