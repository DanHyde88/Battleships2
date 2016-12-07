using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships2
{
    class Game
    {
        // Fields - by default these will be private
        public Player Player1;
        public Player Player2;

        // Methods

        public Game()
        {
            Player1 = new AutoPlayer() { Name = "human", Board = new Board() };
            Player2 = new AutoPlayer() { Name = "computer", Board = new Board() };
            Player2.Populate();
            Player1.Populate();
            Player1.OppositionBoard = Player2.Board;
            Player2.OppositionBoard = Player1.Board;
            Player1.Board.Opposition = Player2;
            Player2.Board.Opposition = Player1;
            Player1.SetDefaultMoves();
            Player2.SetDefaultMoves();
            Player1.Move();
            Player2.Move();
            Player1.Move();
            Player2.Move();
            Player1.Move();
            Player2.Move();
            Player1.Move();
            Player2.Move();
        }

        public static bool CheckForGameOver()
        {
            if (Player1.HitCount == 30 || Player2.HitCount == 30) return true;
            return false;
        }

    }
}
