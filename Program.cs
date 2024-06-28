
using System;

namespace Connect4
{
    class Program
    {
        public static void Main(string[] args)
        {
            StartMenu.StartScreen();
            int gameMode = StartMenu.GetGameMode();
            int difficultyLevel = gameMode == 2 ? StartMenu.GetDifficultyLevel() : 0;

            Game game = new Game(gameMode, difficultyLevel);
            game.Start();
        }

       
    }
}