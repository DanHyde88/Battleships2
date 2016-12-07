using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships2
{
    class Submarine : Ship
    {
        // Fields - by default these will be private
        public static int Amount = 3;
        public static int Count = 0;

        public string Name = "Submarine";
        public override int Length { get; } = 3;
        //public override int[][] Squares;

        public Submarine()
        {
            Count += 1;
        }
    }
}
