using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships2
{
    class Board
    {
        // Fields - by default these will be private
        static int displaySize = 10;
        public int[,] Display = new int[displaySize, displaySize];
        public Player Opposition;

        //Methods

        // Iterates over Display 2 dimensional array setting each element to 0
        public void SetDisplay()
        {
            for (int i = 0; i < displaySize; i++)
            {
                for (int j = 0; j < displaySize; j++)
                {
                    Display[i, j] = 0;
                }
            }
        }

        // Changes Display from 0 to 1 for each array in array, denoting a square of a ship
        public void PlaceShip(int[][] shipSquares)
        {
            foreach (int[] square in shipSquares)
            {
                Display[square[0], square[1]] = 1;
            }
        }

        // Show the board of the player to the same player. i.e. for laying own ships
        public void ShowBoard()
        {
            Console.WriteLine("  0123456789");
            Console.WriteLine("  ||||||||||");
            for (int i = 0; i < displaySize; i++)
            {
                Console.Write(i + "-");
                for (int j = 0; j < displaySize; j++)
                {

                    Console.Write(Display[i, j]);
                }
                Console.WriteLine("");
            }
        }

        public void Show()
        {
            Console.WriteLine("{0}'s turn. Turn number {1}", Opposition.Name, Opposition.TurnCount);
            Console.WriteLine("  0123456789");
            Console.WriteLine("  ||||||||||");
            for (int i = 0; i < displaySize; i++)
            {
                Console.Write(i + "-");
                for (int j = 0; j < displaySize; j++)
                {
                    int[] square = new int[] { i, j };
                    if (SquareVisible(square))
                    {
                        Console.Write(Display[i, j]);
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine("");
            }
        }

        // returns true if parameter square is present in oppositions array of previous moves
        public bool SquareVisible(int[] square)
        {
            for (int i = 0; i < Opposition.Moves.GetLength(0); i++)
            {
                if (square[0] == Opposition.Moves[i][0] && square[1] == Opposition.Moves[i][1]) return true;
            }
            return false;
        }
    }
}
