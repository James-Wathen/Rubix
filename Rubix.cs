using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace RubixCube
{
    class Rubix
    {
        //Must find a way of storing each
        public Subcube[] subcubes = new Subcube[22];//there are only 22 in a cube
        Dictionary<Direction, Side> sides = new Dictionary<Direction, Side>();
        public Rubix(string[] args)
        {
            Side[] cube = new Side[6];
            char[] colours = {'r', 'y', 'g', 'o', 'w', 'b'};
            for(int i = 0; i < cube.Length; i++)//making each side
            //order of directions made are [1,0,0], [0,0,1], [0,1,0], [-1,0,0], [0,-1,0], [0,0,-1]. So only one value needs to be change in the vector.
            {
                int[] direction = {0, 0, 0};
                int x=1;
                if (i > 2)
                    x = -1;
                direction[i%3] = x;//can't believe i came up with this by myself
                cube[i] = new Side(direction, colours[i]);
            }
            foreach (Side side in cube)
            {
                int noSubCubes = 0;
                int Length = cube.GetLength(0);//this should be the number of rows and columns (as it is a cube)
                double mid = (double)Length/2;
                if (mid%1==0)//whole number so works
                {
                    for (int i = 0; i < Length; i++)//going through each row
                    {
                        for (int j = 0; j < Length; j++)//looking at subcubes in this row
                        {
                            if (i!=mid && j!=mid)// look at row except middle subcube
                                checkLocation(side, i, j, subcubes, noSubCubes);
                        }

                    }
                }
                else//mid is not a whole number, so lengths of the sides must be even
                    Console.WriteLine("Cube side lengths are not odd, how odd");
                //Set up subcube in the middle, which is not added to the list of subcubes.
                Dictionary<Direction, char> centralFace = new Dictionary<Direction, char>();
                centralFace.Add(side.returnDirection(), side.returnColour());
                Subcube centralSubCube = new Subcube(centralFace);
                int midInt = Convert.ToInt32(mid);
                side.subcubes[midInt, midInt] = centralSubCube;
            }
            foreach (Side side in cube)
            {
                sides.Add(side.returnDirection(), side);//adds each side to a dictionary of each, easier to find which side during a turn
            }
            printCube(cube);
        }
        public void Turn(bool clockwise, Direction constantAxis)
        {
            Side side = sides[constantAxis];//this is the side which is turned
            Subcube[,] subcubes = side.subcubes;
            //now move each subcube, while also turning it
            
        }
        static void checkLocation(Side side, int i, int j, Subcube[] subcubes, int noSubCubes)
        {
            int[] location = {i, j};
            if (!Adjacent(side, location).returnReal())//no adjacent face so no adjacent subcube
            {
                Dictionary<Direction, char> faces = new Dictionary<Direction, char>();
                faces.Add(side.returnDirection(), side.returnColour());
                Subcube newSubCube = new Subcube(faces);//make new subcube
                side.subcubes[i, j] = newSubCube;// add it to the side
                subcubes[noSubCubes++] = newSubCube;// add it to the list of all subcubes
            }
            else//there is an adjacent subcube
            {
                Adjacent(side, location).AddFace(side.returnDirection(), side.returnColour());//modify the adjacent subcube
                side.subcubes[i, j] = Adjacent(side, location);//add that subcube to this side
            }
        }
        static Subcube Adjacent(Side side, int[] location)//checks if there is a subcube in adjacent to the location in the side
        {
            
        }
        static void printCube(Side[] printedCube)
        {
            foreach (Side side in printedCube)
            {
                side.print();
            }
        }
    }
}