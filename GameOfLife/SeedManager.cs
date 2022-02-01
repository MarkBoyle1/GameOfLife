using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using GameOfLife.Input;
using GameOfLife.Output;
using GameOfLife.SeedGenerator;
using GameOfLife.SeedSaver;

namespace GameOfLife
{
    public class SeedManager
    {
        private readonly IUserInput _input;
        private readonly IOutput _output;
        private readonly string _filePath;
        private ISeedSaver _seedSaver;
        private List<GenerationInfo> _savedSeeds;

        public SeedManager(IUserInput input, IOutput output, string filePath = Constants.JsonSavedSeedsFilePath)
        {
            _input = input;
            _output = output;
            _filePath = filePath;
            _seedSaver = new JSONSeedSaver(_filePath);
            _savedSeeds = LoadSeeds();
        }
        
        public GenerationInfo GetSeedGeneration()
        {
            ISeedGenerator seedGenerator;
            
            bool userWantsToLoadASeed = _savedSeeds.Count > 0 && CheckIfUserWantsToUseASavedSeed();

            if (userWantsToLoadASeed)
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

            return new GenerationInfo(width, height, livingCells);
        }

        private List<GenerationInfo> LoadSeeds()
        {
            try
            {
                return _seedSaver.LoadSavedSeeds();
            }
            catch (FileNotFoundException)
            {
                _output.DisplayMessage(OutputMessages.NoExternalFileFound);
                return new List<GenerationInfo>();
            }
            catch (JsonException)
            {
                _output.DisplayMessage(OutputMessages.CannotReadFile);
                return new List<GenerationInfo>();
            }
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
                _output.DisplayMessage(OutputMessages.DisplaySavedSeedOption(seedNumber, savedSeeds[seedNumber].Name));
            }

            string response = _input.GetUserInput();
            
            List<string> possibleResponses = Enumerable.Range(0, savedSeeds.Count)
                .ToList()
                .ConvertAll(value => value.ToString());

            while(!possibleResponses.Contains(response))
            {
                _output.DisplayMessage(OutputMessages.InvalidInput);
                response = _input.GetUserInput();
            }
            
            int selectedSeedNumber = Convert.ToInt16(response);

            return savedSeeds[selectedSeedNumber];
        }

        public bool CheckIfUserWantsToSaveTheSeed()
        {
            _output.DisplayMessage(OutputMessages.WouldYouLikeToSaveTheSeed);
            string response = _input.GetUserInput();
            
            while (response != Constants.YesResponse && response != Constants.NoResponse)
            {
                _output.DisplayMessage(OutputMessages.InvalidInput);
                response = _input.GetUserInput();
            }

            return response == Constants.YesResponse;
        }

        public void SaveSeed(GenerationInfo seedGeneration)
        {
            if (File.Exists(_filePath))
            {
                _output.DisplayMessage(OutputMessages.AskForNameOfSavedSeed);
                string name = _input.GetUserInput();
            
                seedGeneration.Name = name;
                _savedSeeds.Add(seedGeneration);
                _seedSaver.SaveSeeds(_savedSeeds);
            }
        }

        public bool CheckIfSeedIsAlreadySaved(GenerationInfo seed)
        {
            List<int> listOfSeedPositions = seed.LivingCells.Select(cell => cell.Number).ToList();
            
            int numberOfSameSeeds = _savedSeeds
                .Where(savedSeed => savedSeed.Width == seed.Width)
                .Where(savedSeed => savedSeed.Height == seed.Height)
                .Where(savedSeed => savedSeed.LivingCells.Count == seed.LivingCells.Count)
                .Count(savedSeed => savedSeed.LivingCells.Select(cell => cell.Number).All(listOfSeedPositions.Contains));

            return numberOfSameSeeds > 0;
        }
    }
}