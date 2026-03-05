Initial thoughts:
- There are 6 sides, each containing 9 faces, to make 74 faces total, most faces will always be adjacent to the same face on another side.
- That constant though should be inherent, unless I design the cube to work as I store each subcube instead of each face. I think that would be better tbh.
- In that case each side has 1 unmoving subcube and 8 others that are shared with 4 other sides.
- Each side could be identified by the constant subcube, the other subcubes either have 2 or 3 faces. The specific face of that subcube would need to be stored to that side as well.
- This method could allow me to make it so that when one side turns it moves a subcube, and any sides with that subcube would also change the faces they have. (Making a total of 22 subcubes).

Assigning subcubes:
- Each side has an array of subcubes, but they are all shared between at least 2 of these arrays and the 1,1 (middle) subcube in a side's array must always be nul.
- We would have to make a loop to make 22 subcubes. In that loop it would need to know which colours and directions to assign to the subcube, and then which sides, and places in those sides to put the subcube in

Turn of a side:
- So Turn will act on a side, depend on clock or anti, affect every subcube in that side:
    - Turn will act on each subcube, that will cause the direction of at least one of its faces to change
    - Each subcube will be moved within the side array, this will be the rotation around the constant subcube
    - NewSpot method will take the subcube, its constant side, and location in the constant side:
        - This method will look at subcube2's or subecube3's side that is not the same as the constant side. Using this direction and the location in the constant side (after being turned) it will choose a location to store the subcube in the new direction's side.
        - If it is a subcube3 it will go through this process twice for each side that is not the constant.
    - When a subcube is moved it will delete the subcube that used to be in that spot in that side, but I hope this will not be an issue if i just code well.
An important note on this would be that the direction of a particular face cannot become the negative of its current direction, i.e. it cannot go from -y to y. But of course a subcube can but that has no direction soo...

Turning direction:
- This is easily done by the cross product between the unit vector of the direction of a face, and the unit vector of the constant side to produce a vector that is perpendicular to both and therefore the new direction of the face for clockwise rotation.

After each turn the display should change the displayed faces:
- When the information of a side's faces are requested, the side will give the data for each of its subcube's faces that are in the same direction as itself.
- Each subcube face will only have two values, direction: (x, y, z, -x, -y, -z) and colour: (r, o, y, g, b, w)