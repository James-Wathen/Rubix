using System.Drawing;
using System.Runtime.CompilerServices;

namespace RubixCube
{
    class Rubix
    {
        //Must find a way of storing each
        public static void Main(string[] args)
        {
            Subcube[] subcubes = new Subcube[22];//there are only 22 in a cube
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
            
            printCube(cube);
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