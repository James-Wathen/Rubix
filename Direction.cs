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
            int[] cache = new int[3];
            cache[0] = direction[1]*constantAxis.direction[2]-direction[2]*constantAxis.direction[1];
            cache[1] = -(direction[0]*constantAxis.direction[2] - direction[2] * constantAxis.direction[0]);
            cache[2] = direction[0]*constantAxis.direction[1]-direction[1]*constantAxis.direction[0];
            if (clockwise)
                direction = cache;
            else//anti clockwise rotation
                direction = NegateVector(direction);
        }
        static int[] NegateVector(int[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = -vector[i];
            }
            return vector;
        }

    }
}