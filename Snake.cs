using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Direction {Up,Down,Left,Right}

namespace SnakeGame
{
    internal class SnakeHead
    {
        public int previousX, previousY;
        protected int x, y;
        public int xPos 
        { 
            get 
            { 
                return x; 
            } 
            set 
            { 
                previousX = x;
                x = value;
            } 
        }

        public int yPos
        {
            get
            {
                return y;
            }
            set
            {
                previousY = y;
                y = value;
            }
        }

        public Direction direction = Direction.Right;

        public SnakeHead(int xPos = 0, int yPos = 0) 
        {
            this.x = xPos;
            this.y = yPos;
        }

    }

    
}

namespace SnakeGame
{
    internal class SnakePart : SnakeHead
    {
        public SnakePart(int xPos = 0, int yPos = 0)
        {
            this.x = xPos;
            this.y = yPos;
        }
    }
}

