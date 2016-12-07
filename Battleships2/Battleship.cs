using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships2
{
    class Battleship : Ship
    {
        // Fields - by default these will be private
        public static int Amount = 2;
        public static int Count = 0;

        public string Name = "Battleship";
        public override int Length { get; } = 4;
        //public int[][] Squares { get; set; }

        public Battleship ()
        {
            Count += 1;
        }
    }
}
