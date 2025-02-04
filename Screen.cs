using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;

namespace SnakeGame
{
    internal class Screen
    {
        private int width, height;
        private char[,] field;
        private Random random = new Random();
        private int delay = 0;
        private int count = 0;
        SnakeHead initialSnake = new SnakeHead();
        Collectable plus = new Collectable(0,0);
        private List<SnakePart> parts = new List<SnakePart>();
        private int[] previousInitialCoords = {0,0};

        public Screen(int height, int width)
        {
            field = new char[height, width];
            this.height = height;
            this.width = width;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    field[i, j] = '.';
                }
            }

            field[initialSnake.xPos, initialSnake.yPos] = 'O';
        }

        public int Start()
        {

            plus.ChangePos(random.Next(1, height - 1), random.Next(1, width - 1));

            while (true)
            {

                field[plus.xPos, plus.yPos] = '+';

                for (int i = 0; i < height; i++)
                {
                    if (i > 0)
                        Console.WriteLine();
                    for (int j = 0; j < width; j++)
                    {
                        Console.Write($"{field[i, j]} ");
                    }
                }

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true); 

                    if (key.Key == ConsoleKey.Escape) 
                        break;

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            initialSnake.direction = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            initialSnake.direction = Direction.Down;
                            break;
                        case ConsoleKey.LeftArrow:
                            initialSnake.direction = Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            initialSnake.direction = Direction.Right;
                            break;
                    }
                
                }

                

                field[initialSnake.xPos, initialSnake.yPos] = '.';

                switch (initialSnake.direction)
                {
                    case Direction.Left:
                        if (initialSnake.yPos == 0)
                            return -1;

                        if (initialSnake.yPos - 1 < 0)
                            break;
                        else
                        {
                            field[initialSnake.xPos, initialSnake.yPos] = '.';

                            previousInitialCoords[0] = initialSnake.xPos;
                            previousInitialCoords[1] = initialSnake.yPos;                            

                            initialSnake.yPos -= 1;
                            field[initialSnake.xPos, initialSnake.yPos] = 'O';                            
                        }
                        break;
                    case Direction.Right:
                        if (initialSnake.yPos == width - 1)
                            return -1;

                        if (initialSnake.yPos + 1 >= width)
                            break;
                        else 
                        {                          
                            field[initialSnake.xPos, initialSnake.yPos] = '.';

                            previousInitialCoords[0] = initialSnake.xPos;
                            previousInitialCoords[1] = initialSnake.yPos;
                            
                            initialSnake.yPos += 1;
                            field[initialSnake.xPos, initialSnake.yPos] = 'O';                            
                        }
                        break;
                    case Direction.Up:
                        if (initialSnake.xPos == 0)
                            return -1;

                        if (initialSnake.xPos - 1 < 0)
                            break;
                        else
                        {
                            field[initialSnake.xPos, initialSnake.yPos] = '.';

                            previousInitialCoords[0] = initialSnake.xPos;
                            previousInitialCoords[1] = initialSnake.yPos;
                            
                            initialSnake.xPos -= 1;
                            field[initialSnake.xPos, initialSnake.yPos] = 'O';                            
                        }
                        break;
                    case Direction.Down:
                        if (initialSnake.xPos == height - 1)
                            return -1;

                        if (initialSnake.xPos + 1 >= height)
                            break;
                        else
                        {                            
                            field[initialSnake.xPos, initialSnake.yPos] = '.';

                            previousInitialCoords[0] = initialSnake.xPos;
                            previousInitialCoords[1] = initialSnake.yPos;
                            
                            initialSnake.xPos += 1;
                            field[initialSnake.xPos, initialSnake.yPos] = 'O';  
                        }
                        break;
                }

                for (int i = 0; i < parts.Count; i++)
                {
                    if (initialSnake.xPos == parts[i].xPos && initialSnake.yPos == parts[i].yPos)
                        return -1;

                    if (i == 0)
                    {
                        if (i == parts.Count - 1)
                            field[parts[i].xPos, parts[i].yPos] = '.';

                        parts[i].xPos = previousInitialCoords[0];
                        parts[i].yPos = previousInitialCoords[1];
                        field[parts[i].xPos, parts[i].yPos] = 'O';
                    }
                    else
                    {
                        if (i == parts.Count - 1)
                            field[parts[i].xPos, parts[i].yPos] = '.';

                        parts[i].xPos = parts[i - 1].previousX;
                        parts[i].yPos = parts[i - 1].previousY;
                        field[parts[i].xPos, parts[i].yPos] = 'O';
                    }
                }

                if (initialSnake.xPos == plus.xPos && initialSnake.yPos == plus.yPos)
                {
                    plus.isCollected = true;
                    Console.Beep();
                }

                if(plus.isCollected)
                {
                    count++;

                    plus.ChangePos(random.Next(1, height-1), random.Next(1, width - 1));
                    field[plus.xPos, plus.yPos] = '+';
                    plus.isCollected = false;

                    if (count == 1)
                    {
                        parts.Add(new SnakePart(initialSnake.previousX, initialSnake.previousY));
                    }
                    else
                    {
                        parts.Add(new SnakePart(parts[parts.Count - 1].previousX, parts[parts.Count - 1].previousY));
                    }
                    
                }



                Thread.Sleep(50);
                Console.Clear();

                


            }
            return -1;
        }


    }
}
