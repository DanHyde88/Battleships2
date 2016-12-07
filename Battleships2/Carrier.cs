using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships2
{
    class Carrier : Ship
    {
        // Fields - by default these will be private
        public static int Amount = 1;
        public static int Count = 0;

        public string Name = "Carrier";
        public override int Length { get; } = 5;
        //public override int[][] Squares;

        public Carrier()
        {
            Count += 1;
        }
    }
}
