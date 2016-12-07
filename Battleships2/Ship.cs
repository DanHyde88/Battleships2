using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships2
{
    abstract class Ship // Abstract classes are able to define abstract members.
    {
        public abstract int Length { get; }
        //public abstract int[][] Squares { get; set; }
    }
}
