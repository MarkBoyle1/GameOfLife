namespace GameOfLife
{
    public class OutputMessages
    {
        public const string InvalidInput = "Invalid Input. Please Try Again.";
        public const string EnterGridWidth = "Please enter the grid width:";
        public const string EnterGridHeight = "Please enter the grid height";
        public const string SelectLivingCellsForSeedGeneration = "Please enter the living cells for seed generation:";

        public static string ChooseSelectionGridAction()
        {
            return "Up = " + Constants.Up
                           + "Down = " + Constants.Down
                           + "Left = " + Constants.Left
                           + "Right = " + Constants.Right
                           + "Selected/Deselect = " + Constants.SelectDeselect
                           + "Finished Selecting = " + Constants.FinishedSelecting
                           + "Please select an action:";
        }

        public static string GridMeasurementTooLow()
        {
            return "Invalid number. The minimum number possible is " + Constants.MinimumGridMeasurement;
        }
    }
}