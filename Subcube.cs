using System.Security.Cryptography.X509Certificates;

namespace RubixCube
{
    public class Subcube
    {
        //Subcube can either have 2 or 3 faces importantly, and there must only be 12 ones of 2 (for each vertex) and 8 ones of 3
        public Dictionary<Direction, char> faces = new Dictionary<Direction, char>();
        bool real;
        public Subcube(Dictionary<Direction, char> faces)//array of 3d vectors
        {
            this.faces = faces;
        }
        public void AddFace(Direction direction, char colour)
        {
            faces.Add(direction, colour);
        }
        public void TurnFaces(bool clockwise, Direction constantAxis)
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
        public bool returnReal()
        {
            return real;
        }

    }
}