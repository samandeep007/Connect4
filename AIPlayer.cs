using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    internal    class AIPlayer : Player
    {
        private Random random;
        private int difficultyLevel;

        public AIPlayer(char symbol, int difficultyLevel) : base(symbol)
        {
            random = new Random();
            this.difficultyLevel = difficultyLevel;
        }

        public override void MakeMove(Board board)
        {
            int column = GetBestMove(board, difficultyLevel);
            board.MakeMove(column, Symbol);
            Console.WriteLine($"AI Player {Symbol} placed at column {column + 1}"); // Adjust for display
        }

        private int GetBestMove(Board board, int depth)
        {
            int bestValue = int.MinValue;
            int bestMove = 0;

            for (int c = 1; c <= 7; c++) // Adjust for display
            {
                if (board.IsMoveLegal(c))
                {
                    board.MakeMove(c, Symbol);
                    int moveValue = Minimax(board, depth - 1, false, int.MinValue, int.MaxValue);
                    board.UndoMove(c);

                    if (moveValue > bestValue)
                    {
                        bestMove = c;
                        bestValue = moveValue;
                    }
                }
            }
            return bestMove;
        }

        private int Minimax(Board board, int depth, bool isMaximizing, int alpha, int beta)
        {
            int score = board.Evaluate(Symbol);
            if (score == 1000 || score == -1000 || depth == 0 || board.IsFull())
            {
                return score;
            }

            if (isMaximizing)
            {
                int best = int.MinValue;

                for (int c = 1; c <= 7; c++) // Adjust for display
                {
                    if (board.IsMoveLegal(c))
                    {
                        board.MakeMove(c, Symbol);
                        best = Math.Max(best, Minimax(board, depth - 1, !isMaximizing, alpha, beta));
                        board.UndoMove(c);

                        alpha = Math.Max(alpha, best);
                        if (beta <= alpha) break;
                    }
                }
                return best;
            }
            else
            {
                int best = int.MaxValue;

                for (int c = 1; c <= 7; c++) // Adjust for display
                {
                    if (board.IsMoveLegal(c))
                    {
                        board.MakeMove(c, Symbol == 'X' ? 'O' : 'X');
                        best = Math.Min(best, Minimax(board, depth - 1, !isMaximizing, alpha, beta));
                        board.UndoMove(c);

                        beta = Math.Min(beta, best);
                        if (beta <= alpha) break;
                    }
                }
                return best;
            }
        }
    }
}



