using System;
using System.Runtime.InteropServices;

namespace RubixCube
{
    public class Side
    {
        Direction directionSide;
        char colour;
        Dictionary<string, Direction> adjacentDirections = new Dictionary<string, Direction>();//dictionary of row/colum in the array to each direction on the cube
        public Subcube[,] subcubes = new Subcube[3, 3];//but the middle value should always be nul
        public Side(int[] directionVector, char colour)
        {
            directionSide = new Direction(directionVector);
            this.colour = colour;
            Direction north = directionSide.NorthOf();
            Direction east = north.CrossProduct(directionSide);
            adjacentDirections.Add("N", north);
            adjacentDirections.Add("E", east);
            adjacentDirections.Add("S", north.NegateVector());
            adjacentDirections.Add("W", east.NegateVector());
        }
        public void print()
        {
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Console.Write($"{subcubes[i, j].colour(directionSide)} ");//prints colour of that subcube in the direction of the side
                    if (j==2)
                        Console.WriteLine();                
                }
            }
        }
        public void Turn(bool clockwise)
        {
            
        }
        public Subcube adjacentOrientation(int[] location)//checks if there is a subcube in adjacent to the location in the side
        {
            List<Direction> directions = new List<Direction>();
            //find row/column from location
            //If [0] == 0 then check [1] == 0 look north and west
            //If [0] == 1 then check [1] == 2 look east only
            //If [0] == 2 then check [1] == 1 look south only
            //If [0] == 1 && [1] == 1 it is invalid
            //So each index relates to a direction, if two directions are found then two must be looked through
            string[] orienatation = new string[2];//stores the 1 or 2 orientations of location
            //possible orientations are: C0, C2, R0, R2
            if (location[1] == 1 || location[0] == 1)// just look at the non==1 one
            {
                letter = "R";//must be looking at a 
            }
            if (location )

        }
        public Direction returnDirection()
        {
            return directionSide;
        }
        public char returnColour()
        {
            return colour;
        }
    }
}