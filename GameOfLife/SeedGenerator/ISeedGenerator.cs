namespace GameOfLife
{
    public interface ISeedGenerator
    {
        public int MoveActiveCell(int activeCell, int width);
    }
}