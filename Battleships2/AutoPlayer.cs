using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships2
{
    class AutoPlayer : Player
    {

        // Methods

        // method like populate board, goes through the amount of each ship until count matches making and setting each ship
        public override void Populate()
        {
            Board.SetDisplay();

            for (int i = 0; i < 1; i++)
            {
                Board.ShowBoard();
                Carrier ship = new Carrier();
                Console.WriteLine("Set {0} number {1} of {2}", ship.Name, Carrier.Count, Carrier.Amount);
                PositionShip(ship);
            }

            for (int i = 0; i < 2; i++)
            {
                Board.ShowBoard();
                Battleship ship = new Battleship();
                Console.WriteLine("Set {0} number {1} of {2}", ship.Name, Battleship.Count, Battleship.Amount);
                PositionShip(ship);
            }

            for (int i = 0; i < 3; i++)
            {
                Board.ShowBoard();
                Submarine ship = new Submarine();
                Console.WriteLine("Set {0} number {1} of {2}", ship.Name, Submarine.Count, Submarine.Amount);
                PositionShip(ship);
            }

            for (int i = 0; i < 4; i++)
            {
                Board.ShowBoard();
                Destroyer ship = new Destroyer();
                Console.WriteLine("Set {0} number {1} of {2}", ship.Name, Destroyer.Count, Destroyer.Amount);
                PositionShip(ship);
            }

            Board.ShowBoard();
        }

        // get an x,y coordinate array from player
        public override int[] GetSquare()
        {
            Random rnd = new Random();
            int x = rnd.Next(0, 10);
            int y = rnd.Next(0, 10);
            return new[] { y, x };
        }

        // gets a value of 0,1,2,3 denoting north, east, south, west
        public override int GetDirection()
        {
            Random rnd = new Random();
            int direction = rnd.Next(0, 4);
            return direction;
        }
    }
}