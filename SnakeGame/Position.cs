
namespace SnakeGame
{
    public class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        internal bool Matches(Position pos) => pos.X == X && pos.Y == Y;
    }
}
