using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships2
{
    class Destroyer : Ship
    {
        // Fields - by default these will be private
        public static int Amount = 4;
        public static int Count = 0;

        public string Name = "Destroyer";
        public override int Length { get; } = 2;
        //public override int[][] Squares;

        public Destroyer()
        {
            Count += 1;
        }
    }
}
