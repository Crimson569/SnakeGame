using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Collectable
    {
        public Collectable(int x, int y) 
        { 
            xPos = x; yPos = y;
        }
        public bool isCollected = false;
        public int xPos, yPos;

        public void ChangePos(int x, int y)
        {
            xPos = x; yPos = y;
        }
    }
}
