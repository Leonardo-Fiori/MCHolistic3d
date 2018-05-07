# MCHolistic3d

## Anatomy of a Cube

- 12 Triangles (two for each side)
- Vertex Array
- Normals Array
- UV Array
- Triangle Array (1d array)

Vertex Array (array of array):

[0](x,y,z) // contains xyz of each vertex of each triangle
[1](x1,y2,z2)

Normal Array (array of array):

[0](0,1,0) // contains the normals of each vertex (the index refers to the corresponding vertex in the vertex array)
[1](1,0,0)

UV Array (array of array):

[0](0.0,0.0) // contains the positioning of a pixel of the texture on a 2 axis system (the index refers to the corrisponding vertex in the vertex array) 
[1](1.1,1.1)

Triangle Array (simple array):
[0](0) // must be read in groups of three numbers, each group represents the vertices of a triangle
[1](2)
[2](3)

## UVS

Le uv nell'uv array si riferiscono ai vertici in senso antiorario! (stile piano cartesiano)