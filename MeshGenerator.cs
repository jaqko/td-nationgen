using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    public string Landform = "Unidentified";
    public int verticeCount = 0;
    int verticeCheck = 0;
    public int CountUp = 0;
    public int CountDown = 0;
    public GameObject point;
    float maxX = 312;
    float maxZ = 312;
    public Transform pointT;
    Mesh mesh;
    Vector3[] vertices;
    public Vector3 startpoint;

    public int verticeTally = 0;
    int[] triangles;
    Vector3[] xzPos;
    
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape();
        UpdateMesh();
        

    }

    private void FixedUpdate()
    {
        if (verticeTally != verticeCount)
            verticeTally++;

    }
// Update is called once per frame
void CreateShape()
    {

        verticeCount = Mathf.RoundToInt(Random.Range(3, 156) * 0.8f);
        
        if (verticeCount < 9)
            Landform = "Small Island";
        else if (verticeCount < 26)
            Landform = "Island";
        else if (verticeCount < 39)
            Landform = "Small Nation";
        else if (verticeCount < 52)
            Landform = "Nation";
        else if (verticeCount < 78)
            Landform = "Region";
        else if (verticeCount < 115)
            Landform = "Subcontinent";
        else if (verticeCount < 156)
            Landform = "Continent";
        while (verticeCount % 3 != 0)
        {
            verticeCount--;

           
        }
        CountDown = verticeCount;
        for (float i = 0; i < maxX; i++)
        {
            for (float k = 0; k < maxZ; k++)
            {
                var perlin = Mathf.PerlinNoise(i / 10, k / 10);
                if (perlin > .5f)
                {
                    if (verticeCheck != verticeCount)
                    {
                        Debug.LogError("" + perlin);
                        vertices = new Vector3[verticeCount];
                        xzPos = new Vector3[verticeCount];
                        vertices[verticeCheck] = new Vector3((Random.Range(1, 25) * perlin) * (Mathf.Sqrt(verticeCount) * 0.2333f), 0, (Random.Range(1, 25) * perlin) * (Mathf.Sqrt(verticeCount) * 0.2f));
                        xzPos[verticeCheck] = new Vector3(vertices[verticeCheck].x, vertices[verticeCheck].z, verticeCheck);
                        Debug.Log(xzPos[verticeCheck].ToString());
                        pointT.position = vertices[verticeCheck];
                        Instantiate(point, pointT.position, Quaternion.Euler(90, 0, 0));
                        Debug.LogWarning(xzPos[verticeTally].x);
                        triangles = new int[verticeCount];
                        triangles = new int[verticeCheck];
                        verticeCheck++;
                        if (xzPos[CountUp].x > startpoint.x)
                        {
                            startpoint.x = xzPos[CountUp].x;
                        }



                        if (CountUp >= verticeCount)
                            CountUp = verticeCount;
                        else
                            CountUp++;
                    }
                }
            }
        }
        
    }


    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        Debug.LogFormat("Verts: " + vertices.Length);
        Debug.LogFormat ("Tris: " + triangles.Length);
        
    }
}
