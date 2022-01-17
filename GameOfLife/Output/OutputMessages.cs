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