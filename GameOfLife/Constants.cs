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

        public const string LivingCell = "\u25fc";  //medium square
        public const string DeadCell = " ";
    }
}