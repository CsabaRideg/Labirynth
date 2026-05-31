using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthGame
{
    internal class Tile
    {
        public string type = "0";
        public int x;
        public int y;

        public Tile( int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
