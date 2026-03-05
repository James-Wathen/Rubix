using System;
using System.Runtime.InteropServices;

namespace RubixCube
{
    public class Side
    {
        Direction direction;
        char colour;
        Subcube[,] subcubes = new Subcube[3, 3];//but the middle value should always be nul
        public Side(int[] directionVector, char colour)
        {
            foreach (Subcube subcube in subcubes)
            // if it is a 
            {
                subcube.
            }
            direction = new Direction(directionVector);
            this.colour = colour;
        }
        public void print()
        {
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Console.Write($"{subcubes[i, j].colour(direction)} ");//prints colour of that subcube in the direction of the side
                    if (j==2)
                        Console.WriteLine();                
                }
            }
        }
    }
}