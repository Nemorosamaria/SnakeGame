using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    public class Snake
    {
        public Snake(Position headPosition)
        {
            HeadPosition = headPosition;
            Body.Add(new Position(HeadPosition.X, HeadPosition.Y));
        }

        public List<Position> Body { get; } = new List<Position>();
        public Position HeadPosition { get; set; }

        // Moving by removing the last and adding it to the front
        public void Move(Direction direction, bool grow = false)
        {
            if (!grow)
            {
                Body.RemoveAt(Body.Count - 1);
            }

            SetNextHeadPosition(direction);
            Body.Insert(0, new Position(HeadPosition.X, HeadPosition.Y));
        }

        public void SetNextHeadPosition(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    HeadPosition.Y--;
                    break;
                case Direction.Right:
                    HeadPosition.X++;
                    break;
                case Direction.Down:
                    HeadPosition.Y++;
                    break;
                case Direction.Left:
                    HeadPosition.X--;
                    break;
                default:
                    break;
            }
        }

        public Position NextHeadPosition(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Position(HeadPosition.X, HeadPosition.Y--);
                case Direction.Right:
                    return new Position(HeadPosition.X++, HeadPosition.Y);
                case Direction.Down:
                    return new Position(HeadPosition.X, HeadPosition.Y++);
                case Direction.Left:
                    return new Position(HeadPosition.X--, HeadPosition.Y--);
                default:
                    return HeadPosition;
            }
        }
    }
}
