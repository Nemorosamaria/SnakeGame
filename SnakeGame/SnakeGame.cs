using System;
using System.Linq;
using static System.Console;

// TODO: Timer instead of move-on-command
// TODO: Game over on overlapping snake body
// BUG: If turned after eating a berry, no new berry appears
// BUG: ESC button while playing writes a pixel

namespace SnakeGame
{
    public class SnakeGame
    {
        public SnakeGame(int height, int width)
        {
            Height = height;
            Width = width;

            RandomInt = new Random();
            Snake = new Snake(new Position(Width / 2, Height / 2)); // start at the middle
        }

        // Game settings
        public int Height { get; set; }
        public int Width { get; set; }

        // Game values
        private static Random RandomInt;
        private Position BerryPosition { get; set; }
        private Snake Snake { get; set; }
        public Direction Direction { get; set; } = Direction.Right;

        private bool GameOver => Snake.HeadPosition.X == 0 || Snake.HeadPosition.X >= Width-1 || Snake.HeadPosition.Y == 0 || Snake.HeadPosition.Y >= Height-1;
        public int Score { get; set; } = 0;

        public int Run()
        {
            DrawBorder();
            SetBerryPosition();
            Snake.Body.ForEach(pos => DrawPixel(pos));

            while (!GameOver)
            {
                var grow = Snake.HeadPosition.Matches(BerryPosition);

                if (grow)
                {
                    Score++;
                    SetBerryPosition();
                }

                var command = ReadKey();
                ChangeDirection(command.Key);
                MoveSnake(grow);
 
            }

            return Score;
        }

        private void MoveSnake(bool growSnake = false)
        {
            if (!growSnake)
            {
                ClearPixel(Snake.Body[Snake.Body.Count-1]);
            }

            Snake.Move(Direction, growSnake);
            Snake.Body.ForEach(pos => DrawPixel(pos));
        }

        private void SetBerryPosition()
        {
            BerryPosition = new Position(RandomInt.Next(1, Width - 2), RandomInt.Next(1, Height - 2));
            DrawPixel(BerryPosition);
        }

        private void ClearPixel(Position position)
        {
            SetCursorPosition(position.X, position.Y);
            ForegroundColor = BackgroundColor;
            Write("■");
        }

        private void DrawPixel(Position position, ConsoleColor color = ConsoleColor.White)
        {
            SetCursorPosition(position.X, position.Y);
            ForegroundColor = color;
            Write("■");
        }

        private void DrawBorder()
        {
            for (int i = 0; i < Width; i++)
            {
                DrawPixel(new Position(i, 0));
                DrawPixel(new Position(i, Height - 1));
            }

            for (int i = 0; i < Height; i++)
            {
                DrawPixel(new Position(0, i));
                DrawPixel(new Position(Width - 1, i));
            }
        }

        private void ChangeDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Direction = Direction.Up;
                    break;
                case ConsoleKey.RightArrow:
                    Direction = Direction.Right;
                    break;
                case ConsoleKey.DownArrow:
                    Direction = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    Direction = Direction.Left;
                    break;
                default:
                    break;
            }
        }

    }
}
