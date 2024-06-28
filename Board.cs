using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    internal class Board
    {
        private const int Rows = 6;
        private const int Columns = 7;
        private char[,] grid;

        public Board()
        {
            grid = new char[Rows, Columns];
            Reset();
        }

        public void Reset()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    grid[r, c] = ' ';
                }
            }
        }

        public bool IsFull()
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[0, c] == ' ')
                {
                    return false;
                }
            }
            return true;
        }

        public void Display()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  1   2   3   4   5   6   7  ");
            Console.WriteLine("┌───┬───┬───┬───┬───┬───┬───┐");

            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    Console.Write("│ ");
                    if (grid[r, c] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (grid[r, c] == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    Console.Write(grid[r, c]);
                    Console.ResetColor();
                    Console.Write(" ");
                }
                Console.WriteLine("│");

                if (r < Rows - 1)
                {
                    Console.WriteLine("├───┼───┼───┼───┼───┼───┼───┤");
                }
            }

            Console.WriteLine("└───┴───┴───┴───┴───┴───┴───┘");
            Console.ResetColor();
        }

        public bool MakeMove(int column, char symbol)
        {
            column -= 1; // Adjust column index to be zero-based

            if (column < 0 || column >= Columns || grid[0, column] != ' ')
            {
                return false;
            }

            for (int r = Rows - 1; r >= 0; r--)
            {
                if (grid[r, column] == ' ')
                {
                    grid[r, column] = symbol;
                    return true;
                }
            }

            return false;
        }

        public void UndoMove(int column)
        {
            column -= 1; // Adjust column index to be zero-based

            for (int r = 0; r < Rows; r++)
            {
                if (grid[r, column] != ' ')
                {
                    grid[r, column] = ' ';
                    break;
                }
            }
        }

        public bool CheckForWin(char symbol)
        {
            // Check horizontal, vertical, and diagonal lines for a win
            // Horizontal check
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c <= Columns - 4; c++)
                {
                    if (grid[r, c] == symbol && grid[r, c + 1] == symbol && grid[r, c + 2] == symbol && grid[r, c + 3] == symbol)
                    {
                        return true;
                    }
                }
            }

            // Vertical check
            for (int c = 0; c < Columns; c++)
            {
                for (int r = 0; r <= Rows - 4; r++)
                {
                    if (grid[r, c] == symbol && grid[r + 1, c] == symbol && grid[r + 2, c] == symbol && grid[r + 3, c] == symbol)
                    {
                        return true;
                    }
                }
            }

            // Diagonal checks
            // Positive slope
            for (int r = 3; r < Rows; r++)
            {
                for (int c = 0; c <= Columns - 4; c++)
                {
                    if (grid[r, c] == symbol && grid[r - 1, c + 1] == symbol && grid[r - 2, c + 2] == symbol && grid[r - 3, c + 3] == symbol)
                    {
                        return true;
                    }
                }
            }

            // Negative slope
            for (int r = 0; r <= Rows - 4; r++)
            {
                for (int c = 0; c <= Columns - 4; c++)
                {
                    if (grid[r, c] == symbol && grid[r + 1, c + 1] == symbol && grid[r + 2, c + 2] == symbol && grid[r + 3, c + 3] == symbol)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public int Evaluate(char symbol)
        {
            if (CheckForWin(symbol)) return 1000;
            if (CheckForWin(symbol == 'X' ? 'O' : 'X')) return -1000;
            return 0;
        }

        public bool IsMoveLegal(int column)
        {
            column -= 1; // Adjust column index to be zero-based
            return grid[0, column] == ' ';
        }
    }
}