namespace RubixCube
{
    public class Direction
    {
        int[] direction = new int[3];//this is one of x, y, z, -x, -y, -z, but stored as a vector of 3 dimensions
        public Direction(int[] Direction)
        {
            this.direction = Direction;
        }
        public void Turn(bool clockwise, Direction constantAxis)
        {
            //cross product between constantAxis.vector and vector
            Direction crossedDirection = CrossProduct(constantAxis);
            Direction reversedDirection = crossedDirection.NegateVector();//reverse of cross
            if (clockwise)
                direction = crossedDirection.direction;// direction becomes the direction X axis
            else//anti clockwise rotation
                direction = reversedDirection.direction;//this new direction is obviously reverssed for the other direction of turning
        }
        public Direction CrossProduct(Direction Secondary)//cross product of this direction with another
        {
            int[] cache = new int[Secondary.direction.Length];//cache is the cross product of the 
            cache[0] = direction[1]*Secondary.direction[2]-direction[2]*Secondary.direction[1];
            cache[1] = -(direction[0]*Secondary.direction[2] - direction[2] * Secondary.direction[0]);
            cache[2] = direction[0]*Secondary.direction[1]-direction[1]*Secondary.direction[0];
            Direction tempDirection = new Direction(cache);
            return tempDirection;
        }
        public Direction NorthOf()
        {
            int Length = direction.Length;
            int[] cache = new int[Length];
            for (int i = 0; i< Length; i++)//shifts the direction, e.g. [0,1,0] -> [0,0,1]
            {
                if (i==0)
                    cache[i] = direction[^1];
                else
                    cache[i] = direction[i-1];
            }
            Direction newDirection = new Direction(cache);
            return newDirection;
        }
        public Direction NegateVector()//returns the version of this direction that reverses it, no need to make it actually reverse
        //the direction since there is not reason to ever do that
        {
            int[] vector = new int[direction.Length];
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = -vector[i];
            }
            Direction tempDirection = new Direction(vector);
            return tempDirection;
        }

    }
}