using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    internal class Player
    {
        public char Symbol { get; private set; }

        public Player(char symbol)
        {
            Symbol = symbol;
        }

        public virtual void MakeMove(Board board)
        {
            Console.WriteLine($"Player {Symbol}, enter column (0-6): ");
            int column = int.Parse(Console.ReadLine());

            while (!board.MakeMove(column, Symbol))
            {
                Console.WriteLine("Invalid move. Try again.");
                column = int.Parse(Console.ReadLine());
            }


        }
    }

}
