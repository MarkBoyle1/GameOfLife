using System;

namespace GameOfLife
{
    public class Constants
    {
        public const string Left = "a";
        public const string Right = "d";
        public const string Up = "w";
        public const string Down = "s";
        public const string SelectDeselect = "e";
        public const string FinishedSelecting = "q";

        public const string YesResponse = "y";
        public const string NoResponse = "n";

        public const string JsonSavedSeedsFilePath = "JSONSavedSeeds.json";

        public const int TimeBetweenGenerationsInMilliseconds = 200;
        public const int MinimumGridMeasurement = 3;
        public const int NumberOfPreviousGenerationsKeptToCheckForInfiniteLoop = 5;
        public const int StartingCellPositionForManualSelection = 1;
        public const int GenerationLimit = 100;

        public const string LivingCell = "\u25fc";  //medium square
        public const string DeadCell = " ";
        public const string SelectedActiveCell = "\u25a3"; //square within a square
        public const string DeselectedActiveCell = "\u25a2"; //empty square
        public const string SelectedCell = "\u25fc"; //full square
        public const string DeselectedCell = " ";

        public const ConsoleColor ActiveCellColour = ConsoleColor.Magenta;
        public const ConsoleColor SelectedCellColour = ConsoleColor.DarkCyan;
        public const ConsoleColor DefaultColour = ConsoleColor.White;
    }
}