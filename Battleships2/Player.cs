using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships2
{
    class Player
    {
        // Fields - by default these will be private
        public string Name; // Name of player
        public int[][] Moves = new int[100][]; // These are the squares that the player has fired at
        public int HitCount = 0; // Count of moves which have hit
        public int TurnCount = 0; // Count of turns this player has taken
        public Board Board; // Each player will have a board
        public Board OppositionBoard; // The board of the opposition


        // Methods

        //
        public void SetDefaultMoves()
        {
            for (int i=0; i<Moves.GetLength(0); i++)
            {
                int[] defaultMove = new int[] { 10, 10 }; // 10 is not on board so will not interfere with validating real moves
                Moves[i] = defaultMove;
            }
        }

        // method like populate board, goes through the amount of each ship until count matches making and setting each ship
        public virtual void Populate()
        {
            Board.SetDisplay();

            for (int i = 0; i < 1; i++)
            {
                Board.ShowBoard();
                Carrier ship = new Carrier();
                Console.WriteLine("Set {0} number {1} of {2}", ship.Name, i+1, Carrier.Amount);
                PositionShip(ship);
            }

            for (int i = 0; i < 2; i++)
            {
                Board.ShowBoard();
                Battleship ship = new Battleship();
                Console.WriteLine("Set {0} number {1} of {2}", ship.Name, i + 1, Battleship.Amount);
                PositionShip(ship);
            }

            for (int i = 0; i < 3; i++)
            {
                Board.ShowBoard();
                Submarine ship = new Submarine();
                Console.WriteLine("Set {0} number {1} of {2}", ship.Name, i + 1, Submarine.Amount);
                PositionShip(ship);
            }

            for (int i = 0; i < 4; i++)
            {
                Board.ShowBoard();
                Destroyer ship = new Destroyer();
                Console.WriteLine("Set {0} number {1} of {2}", ship.Name, i + 1, Destroyer.Amount);
                PositionShip(ship);
            }

            Board.ShowBoard();
        }

        // Move for a player
        public void Move()
        {
            OppositionBoard.Show();
            int[] move = SolicitSquareForMove();
            Moves[TurnCount] = move;
            TurnCount += 1;
            OppositionBoard.Show();
        }

        // Asks user for a square for move and returns a validated square
        public int[] SolicitSquareForMove()
        {
            int[] square = GetSquare();
            if (ValidateSquareOnBoard(square) && ValidateUniqueMove(square)) { return square; }
            else return SolicitSquareForMove();
        }

        // returns true if the parameter square (move) hits a target
        public void Hit(int[] square)
        {
            if (OppositionBoard.Display[square[0], square[1]] == 1) { HitCount += 1; }
        }

        // Asks user for an initial square to place ship and returns a validated square
        public int[][] SolicitShip(Ship ship)
        {
            int[] square = GetSquare();
            int direction = GetDirection();
            int[][] shipSquares = ShipLocation(square, direction, ship);
            if (ValidateShipSquares(shipSquares)) return shipSquares;
            else return SolicitShip(ship);
        }

        // Places one ship on the same players board
        public void PositionShip(Ship ship)
        {
            int[][] shipSquares = SolicitShip(ship);
            //ship.Squares = shipSquares; // sets Squares property of ship
            Board.PlaceShip(shipSquares); // updates the display so the squares = 1, instead of default empty of 0.
        }

        // get an x,y coordinate array from player
        public virtual int[] GetSquare()
        {
            Console.WriteLine("Enter the x coordinate");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the y coordinate");
            int y = Convert.ToInt32(Console.ReadLine());
            return new[] { y, x };
        }

        // gets a value of 0,1,2,3 denoting north, east, south, west
        public virtual int GetDirection()
        {
            Console.WriteLine("Enter 0,1,2 or 3 for North, East, South or West");
            int d = Convert.ToInt32(Console.ReadLine());
            if (ValidateDirection(d)) { return d; }
            else return GetDirection();
        }

        // Validates that each element of the array is between 0-9 inclusive and the array length is 2
        public bool ValidateSquareOnBoard(int[] square)
        {
            if (square[0] < 0 || square[0] > 9 || square[1] < 0 || square[1] > 9)
            {
                return false;
            }
            else if (square.Length != 2)
            {
                return false;
            }
            else return true;
        }

        // Validates that each element of the array is between 0-9 inclusive and the array length is 2
        public bool ValidateUniqueMove(int[] square)
        {
            for (int i=0; i < Moves.GetLength(0); i++)
            {
                if (square[0] == Moves[i][0] && square[1] == Moves[i][1]) return false;
            }
            return true;
        }

        // Validates that the array (square) has not already been used
        public bool ValidateSquareFree(int[] square)
        {
            if (Board.Display[square[0], square[1]] == 0)
            {
                return true;
            }
            else return false;
        }

        // Validates that all ship squares are free given an array of squares
        public bool ValidateShipSquares(int[][] shipSquares)
        {
            foreach (int[] square in shipSquares)
            {
                if (!ValidateSquareOnBoard(square) || !ValidateSquareFree(square))
                {
                    Console.WriteLine("validate attempt");
                    return false;
                }
            }
            return true;
        }

        // Validates that the integer parameter is 0,1,2 or 3 to denote north, east, south or west
        public bool ValidateDirection(int d)
        {
            if (d == 0 || d==1 || d==2 || d==3)
            {
                return true;
            }
            else return false;
        }

        // Returns an array of arrays of square coordinates the ship will occupy
        public int[][] ShipLocation (int[] initial, int direction, Ship ship)
        {
            int[][] shipSquares = new int[ship.Length][];

            // x and y are in opposite positions to expected because a 2 dimensional array order is opposite to cartesian
            for (int i=0; i<ship.Length; i++)
            {
                int x = initial[0];
                int y = initial[1];
                switch (direction)
                {
                    case 0:
                        x -= i;
                        break;
                    case 1:
                        y += i;
                        break;
                    case 2:
                        x += i;
                        break;
                    case 3:
                        y -= i;
                        break;
                }
                shipSquares[i] = new int[] { x, y };
            }
            return shipSquares;
        }



    }
}
