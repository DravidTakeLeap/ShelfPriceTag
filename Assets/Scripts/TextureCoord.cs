using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureCoord : MonoBehaviour
{
    public GameObject sphere;
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                GameObject go = Instantiate(sphere, TextureToWorldCoord(new Vector2( i * 0.125f, 1 - (j * 0.125f))), Quaternion.identity);
                go.name = "product_" + i + " " + j;
            }
        }
        //Instantiate(sphere, TextureToWorldCoord(new Vector2(0f, 0.125f)), Quaternion.identity);
        //Debug.Log((Time.realtimeSinceStartup).ToString());
    }

    void Update()
    {
        var a1 = 2.0f;
    }

    private Vector3 TextureToWorldCoord(Vector2 UVCoord)
    {
       // Debug.Log((double)Time.time);

        

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        int[] triangles = mesh.triangles;
        Vector2[] uvs = mesh.uv;
        Vector3[] vertices = mesh.vertices;

        for (int i = 0; i < triangles.Length; i += 3)  //3 being the 3 vertices of the triangle
        {
            Vector2 u1 = uvs[triangles[i]];
            Vector2 u2 = uvs[triangles[i + 1]];
            Vector2 u3 = uvs[triangles[i + 2]];

            //Calculating the Area of Triangles
            float area = Area(u1, u2, u3); if (area == 0) continue; //Skip if Area is zero

            //Barycentric Coordinates
            float area1 = Area(u2, u3, UVCoord) / area; if (area1 < 0) continue; //If outside any of the area(s) of triangle skip
            float area2 = Area(u3, u1, UVCoord) / area; if (area2 < 0) continue;
            float area3 = Area(u1, u2, UVCoord) / area; if (area3 < 0) continue;

            Vector3 p3D = area1 * vertices[triangles[i]] + area2 * vertices[triangles[i + 1]] + area3 * vertices[triangles[i + 2]];

            
            //Interpolation between point and mesh position
            return transform.TransformPoint(p3D);        
        }
            //Point outside the UV Triangle
            return Vector3.zero;
    }

    private float Area(Vector2 p1, Vector2 p2, Vector2 p3)
    {
        Vector2 v1 = p1 - p3;
        Vector2 v2 = p2 - p3;

        return (v1.x * v2.y - v1.y * v2.x) / 2;
    }
}
