namespace GameOfLife
{
    public class Cell
    {
        public int Position;
        public bool IsAlive { get; }

        public Cell(int position, bool isAlive)
        {
            Position = position;
            IsAlive = isAlive;
        }
    }
}