namespace GameOfLife
{
    public class OutputMessages
    {
        public const string InvalidInput = "Invalid Input. Please Try Again.";
        public const string EnterGridWidth = "Please enter the grid width:";
        public const string EnterGridHeight = "Please enter the grid height";
        public const string SelectLivingCellsForSeedGeneration = "Please enter the living cells for seed generation:";
        public const string AskIfUserWantsToLoadSavedSeed = "Do you want to load a saved seed? y/n :";
        public const string SavedSeedSelection = "Please enter the number of the choosen seed: ";
        public const string WouldYouLikeToSaveTheSeed = "Would you like to save the seed generation?: y/n";
        public const string AskForNameOfSavedSeed = "Please enter the name of this seed:";
        public const string NoExternalFileFound = "No external file found";

        public static string ChooseSelectionGridAction()
        {
            return "Up = " + Constants.Up + System.Environment.NewLine
                           + "Down = " + Constants.Down + System.Environment.NewLine
                           + "Left = " + Constants.Left + System.Environment.NewLine
                           + "Right = " + Constants.Right + System.Environment.NewLine
                           + "Selected/Deselect = " + Constants.SelectDeselect + System.Environment.NewLine
                           + "Finished Selecting = " + Constants.FinishedSelecting + System.Environment.NewLine
                           + "Please select an action:";
        }

        public static string GridMeasurementTooLow()
        {
            return "Invalid number. The minimum number possible is " + Constants.MinimumGridMeasurement;
        }
    }
}