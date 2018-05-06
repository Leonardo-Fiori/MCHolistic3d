using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshInfo : MonoBehaviour
{

    public GameObject marker;

    MeshFilter meshFilter;
    Mesh mesh;

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
        Stampa();
    }

    private void Stampa()
    {
        string vertices = "";
        string uvs = "";
        string triangles = "";
        string normals = "";

        foreach (Vector3 vertex in mesh.vertices)
        {
            vertices += vertex + " ";
        }

        foreach (Vector2 uv in mesh.uv)
        {
            vertices += uv + " ";
        }

        foreach (int triangle in mesh.triangles)
        {
            triangles += triangle + " ";
        }

        foreach (Vector3 normal in mesh.normals)
        {
            normals += normal + " ";

        }

        print("VERTICI: " + vertices + "\n\nUVS: " + uvs + "\n\nTRIANGOLI: " + triangles + "\n\nNORMALI: " + normals);
    }

}