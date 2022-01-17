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

        public const int TimeBetweenGenerationsInMilliseconds = 100;
        public const int MinimumGridMeasurement = 3;

        public const string LivingCell = "\u25fc";  //medium square
        public const string DeadCell = " ";
        public const string SelectedActiveCell = "\u25a3"; //square within a square
        public const string DeselectedActiveCell = "\u25a2"; //empty square
        public const string SelectedCell = "\u25fc"; //full square
        public const string DeselectedCell = " ";
    }
}