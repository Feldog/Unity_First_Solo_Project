using UnityEngine;

public class StudyPolygon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Mesh mesh = new Mesh(); // 형태 데이터가 들어갈 Mesh 타입의 변수 생성

        Vector3[] vertices = new Vector3[] {    // Vertex데이터
            new Vector3(0, 0, 0), // Vertex 0
            new Vector3(1, 0, 0), // Vertex 1
            new Vector3(0, 1, 0), // Vertex 2
            new Vector3(1, 1, 0) // Vertex 3
        };

        int[] triangles = new int[]
        {
            0, 2, 1, // Triangle 1
            3, 1, 2  // Triangle 2
        };

        Vector2[] uv = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        MeshRenderer meshRender = gameObject.AddComponent<MeshRenderer>();
        meshRender.material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    }

}
