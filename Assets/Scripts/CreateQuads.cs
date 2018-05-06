using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Cubeside
{
    FRONT,
    BACK,
    TOP,
    BOTTOM,
    LEFT,
    RIGHT
}

public class CreateQuads : MonoBehaviour
{

    public Material cubeMaterial;

    void CreateQuad(Cubeside side)
    {
        Mesh mesh = new Mesh();
        mesh.name = "Scripted Mesh";

        Vector3[] vertici = new Vector3[4];
        Vector3[] normali = new Vector3[4];
        Vector2[] uvs = new Vector2[4];
        int[] triangoli = new int[6];

        // Creo i vertici

        Vector3 p0 = new Vector3(-0.5f, -0.5f, 0.5f);
        Vector3 p1 = new Vector3(0.5f, -0.5f, 0.5f);
        Vector3 p2 = new Vector3(0.5f, -0.5f, -0.5f);
        Vector3 p3 = new Vector3(-0.5f, -0.5f, -0.5f);
        Vector3 p4 = new Vector3(-0.5f, 0.5f, 0.5f);
        Vector3 p5 = new Vector3(0.5f, 0.5f, 0.5f);
        Vector3 p6 = new Vector3(0.5f, 0.5f, -0.5f);
        Vector3 p7 = new Vector3(-0.5f, 0.5f, -0.5f);

        // Creo le UVs

        Vector2 uv00 = new Vector2(0f, 0f);
        Vector2 uv10 = new Vector2(1f, 0f);
        Vector2 uv01 = new Vector2(0f, 1f);
        Vector2 uv11 = new Vector2(1f, 1f);

        // Aggruppo i triangoli

        triangoli = new int[] { 3, 1, 0, 3, 2, 1 };

        // Creo le normali e inizializzo array vertici, uv e triangoli in base al lato

        switch (side)
        {
            case Cubeside.BOTTOM:
                vertici = new Vector3[] { p0, p1, p2, p3 };
                normali = new Vector3[] {Vector3.down, Vector3.down,
                                            Vector3.down, Vector3.down};
                uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                triangoli = new int[] { 3, 1, 0, 3, 2, 1 };
                break;
            case Cubeside.TOP:
                vertici = new Vector3[] { p7, p6, p5, p4 };
                normali = new Vector3[] {Vector3.up, Vector3.up,
                                            Vector3.up, Vector3.up};
                uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                triangoli = new int[] { 3, 1, 0, 3, 2, 1 };
                break;
            case Cubeside.LEFT:
                vertici = new Vector3[] { p7, p4, p0, p3 };
                normali = new Vector3[] {Vector3.left, Vector3.left,
                                            Vector3.left, Vector3.left};
                uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                triangoli = new int[] { 3, 1, 0, 3, 2, 1 };
                break;
            case Cubeside.RIGHT:
                vertici = new Vector3[] { p5, p6, p2, p1 };
                normali = new Vector3[] {Vector3.right, Vector3.right,
                                            Vector3.right, Vector3.right};
                uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                triangoli = new int[] { 3, 1, 0, 3, 2, 1 };
                break;
            case Cubeside.FRONT:
                vertici = new Vector3[] { p4, p5, p1, p0 };
                normali = new Vector3[] {Vector3.forward, Vector3.forward,
                                            Vector3.forward, Vector3.forward};
                uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                triangoli = new int[] { 3, 1, 0, 3, 2, 1 };
                break;
            case Cubeside.BACK:
                vertici = new Vector3[] { p6, p7, p3, p2 };
                normali = new Vector3[] {Vector3.back, Vector3.back,
                                            Vector3.back, Vector3.back};
                uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                triangoli = new int[] { 3, 1, 0, 3, 2, 1 };
                break;
        }

        // Creo la mesh

        mesh.vertices = vertici;
        mesh.triangles = triangoli;
        mesh.uv = uvs;
        mesh.normals = normali;

        mesh.RecalculateBounds();

        // Crea un oggetto a cui assegnare la mesh

        GameObject quad = new GameObject("quad");
        quad.transform.parent = this.transform;

        // Creo un meshfilter da dare all'oggetto

        MeshFilter newMeshFilter = (MeshFilter) quad.AddComponent<MeshFilter>();
        newMeshFilter.mesh = mesh;

        // Creo un meshrenderer da dare all'oggetto

        MeshRenderer newMeshRenderer = (MeshRenderer) quad.AddComponent<MeshRenderer>();
        newMeshRenderer.material = cubeMaterial;
    }

    void CombineQuads()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        for(int i = 0; i < combine.Length; i++)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
        }

        MeshFilter newMeshFilter = (MeshFilter) gameObject.AddComponent<MeshFilter>();
        newMeshFilter.mesh = new Mesh();
        newMeshFilter.mesh.CombineMeshes(combine);

        MeshRenderer newMeshRenderer = (MeshRenderer)gameObject.AddComponent<MeshRenderer>();
        newMeshRenderer.material = cubeMaterial;

        foreach(Transform quad in transform)
        {
            Destroy(quad.gameObject);
        }

    }

    void CreateCube()
    {
        CreateQuad(Cubeside.FRONT);
        CreateQuad(Cubeside.BACK);
        CreateQuad(Cubeside.TOP);
        CreateQuad(Cubeside.BOTTOM);
        CreateQuad(Cubeside.LEFT);
        CreateQuad(Cubeside.RIGHT);
        CombineQuads();
    }

    void Start()
    {
        CreateCube();
    }

}
