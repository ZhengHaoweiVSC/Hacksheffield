using UnityEngine;

public class ProceduralGenerationBackground : MonoBehaviour
{
    [Header("Horizontal Settings")]
    [SerializeField] int tilesInFront = 10;  // tiles to the right
    [SerializeField] int tilesBehind = 5;    // tiles to the left

    [Header("Vertical Settings")]
    [SerializeField] int rowsAbove = 1;
    [SerializeField] int rowsBelow = 1;

    [Header("Background Prefab")]
    [SerializeField] GameObject backgroundPrefab;

    void Start()
    {
        Generate();
    }

    void Generate()
    {
        SpriteRenderer sr = backgroundPrefab.GetComponent<SpriteRenderer>();

        float tileWidth = sr.bounds.size.x;
        float tileHeight = sr.bounds.size.y;

        // Generate center row
        GenerateRow(0, tileWidth);

        // Generate rows above
        for (int i = 1; i <= rowsAbove; i++)
            GenerateRow(i * tileHeight, tileWidth);

        // Generate rows below
        for (int i = 1; i <= rowsBelow; i++)
            GenerateRow(-i * tileHeight, tileWidth);
    }

    void GenerateRow(float yOffset, float tileWidth)
    {
        // Spawn behind (left side)
        for (int i = 1; i <= tilesBehind; i++)
        {
            Vector2 pos = new Vector2(-i * tileWidth, yOffset);
            SpawnTile(pos);
        }

        // Spawn center → right side
        for (int i = 0; i < tilesInFront; i++)
        {
            Vector2 pos = new Vector2(i * tileWidth, yOffset);
            SpawnTile(pos);
        }
    }

    void SpawnTile(Vector2 position)
    {
        GameObject obj = Instantiate(backgroundPrefab, position, Quaternion.identity);
        obj.transform.parent = this.transform;
    }
}