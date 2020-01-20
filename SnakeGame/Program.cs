using System;
using static System.Console;

namespace SnakeGame
{
    class Program
    {
        // args: size?
        static void Main(string[] args)
        {
            var gameHeight = 16;
            var gameWidth = 32;
            CursorVisible = false;

            var exit = false;
            while (!exit)
            {
                Clear();
                WriteLine("SNAKE GAME!");
                WriteLine("Press any button to start...");
                ReadKey();
                Clear();

                var gameInstance = new SnakeGame(gameHeight, gameWidth); // Construct game
                var score = gameInstance.Run(); // Run game

                exit = GameOver(score);
            }

            Environment.Exit(0);
        }

        static bool GameOver(int score)
        {
            Clear();
            WriteLine($"Game Over! You scored: {score}");
            WriteLine("Press ESC to exit, or any other key to start again...");

            var keyPressed = ReadKey();
            return keyPressed.Key == ConsoleKey.Escape;
        }
    }
}
