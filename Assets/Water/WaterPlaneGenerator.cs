using UnityEngine;

public class WaterPlaneGenerator : MonoBehaviour
{
    public float size = 1;
    public int gridSize = 16;

    private void Start()
    {
        MeshFilter filter = gameObject.GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        filter.mesh = mesh;

        Vector3[] vertices = new Vector3[(gridSize + 1) * (gridSize + 1)];
        int[] triangles = new int[gridSize * gridSize * 6];

        for (int i = 0, y = 0; y <= gridSize; y++)
        {
            for (int x = 0; x <= gridSize; x++, i++)
            {
                vertices[i] = new Vector3(x * size, 0, y * size);
            }
        }

        for (int ti = 0, vi = 0, y = 0; y < gridSize; y++, vi++)
        {
            for (int x = 0; x < gridSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + gridSize + 1;
                triangles[ti + 5] = vi + gridSize + 2;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
