namespace RubixCube
{
    public abstract class Subcube
    {
        //Subcube can either have 2 or 3 faces importantly, and there must only be 12 ones of 2 (for each vertex) and 8 ones of 3
        Dictionary<Direction, char> faces = new Dictionary<Direction, char>();
        public Subcube(char[] facesColours, int[][] facesDirections)//array of 3d vectors
        {
            for (int i = 0; i < facesColours.Length; i++)
            {
                Direction direction = new Direction(facesDirections[i]);
                faces.Add(direction, facesColours[i]);
            }
        }
        public virtual void TurnFaces(bool clockwise, Direction constantAxis)
        {
            foreach (KeyValuePair<Direction, char> face in faces)//direction (key) of each face should be changed if it is not the constant
            {
                if (face.Key != constantAxis)
                {
                    face.Key.Turn(clockwise, constantAxis);//changes direction of the face
                }
            }
        }
        public char colour(Direction direction)
        {
            return faces[direction];//return colour of face in that direction
        }

    }
}