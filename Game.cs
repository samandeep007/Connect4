using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    internal class Game
    {
        private Board board;
        private Player player1;
        private Player player2;

        public Game(int gameMode, int difficultyLevel)
        {
            board = new Board();
            player1 = new Player('X');

            if (gameMode == 1)
            {
                player2 = new Player('O');
            }
            else if (gameMode == 2)
            {
                player2 = new AIPlayer('O', difficultyLevel);
            }
        }

        public void Start()
        {
            Player currentPlayer = player1;
            bool gameWon = false;

            while (!board.IsFull())
            {
                board.Display();
                currentPlayer.MakeMove(board);

                if (board.CheckForWin(currentPlayer.Symbol))
                {
                    gameWon = true;
                    board.Display();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Player {currentPlayer.Symbol} wins!");
                    Console.ResetColor();
                    break;
                }
                else
                {
                    currentPlayer = currentPlayer == player1 ? player2 : player1;
                }
            }

            if (!gameWon)
            {
                board.Display();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The game is a draw!");
                Console.ResetColor();
            }

            AskForRestart();
        }

        private void AskForRestart()
        {
            Console.WriteLine("Use arrow keys to select an option and press Enter:");

            string[] options = { "Restart", "Main Menu", "Exit" };
            int selectedIndex = 0;

            while (true)
            {
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"> {options[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {options[i]}");
                    }
                }

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (options[selectedIndex] == "Restart")
                    {
                        board.Reset();
                        Start();
                    }
                    else if (options[selectedIndex] == "Main Menu")
                    {
                        Program.Main(new string[0]);
                    }
                    else if (options[selectedIndex] == "Exit")
                    {
                        Environment.Exit(0);
                    }
                }

                Console.Clear();
                Console.WriteLine("Use arrow keys to select an option and press Enter:");
            }
        }
    }

}
