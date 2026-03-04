using UnityEngine;

public class TerrainEraser : MonoBehaviour
{

    public Terrain terrain;
    public float brushSize = 0.02f; // Size of the eraser
    public float brushStrength = 0.0f; // Height to set (0 = lowest)

    void Update()
    {
        if (Input.GetMouseButton(0)) // Left mouse button
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.collider.gameObject == terrain.gameObject)
                {
                    EraseTerrain(hit.point);
                }
            }
        }
    }

    void EraseTerrain(Vector3 worldPos)
    {
        TerrainData td = terrain.terrainData;
        
        // 1. Convert world position to terrain local position
        Vector3 terrainLocalPos = worldPos - terrain.transform.position;
        Vector2 normalizedPos = new Vector2(terrainLocalPos.x / td.size.x, terrainLocalPos.z / td.size.z);

        // 2. Calculate pixel coordinates
        int xBase = (int)(normalizedPos.x * td.heightmapResolution);
        int yBase = (int)(normalizedPos.y * td.heightmapResolution);

        // 3. Define the area to erase
        int size = 20; // Radius in pixels
        xBase -= size / 2;
        yBase -= size / 2;

        // 4. Get current heights and set new heights
        float[,] heights = td.GetHeights(xBase, yBase, size, size);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                heights[i, j] = brushStrength; // Set height to 0
            }
        }
        
        // 5. Apply changes
        td.SetHeightsDelayLOD(xBase, yBase, heights);
    }
}


