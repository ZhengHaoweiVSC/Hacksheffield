using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private int playerGold;
    public GameObject chestPrefab;
    private float spawnInterval = 8;
    private float lastSpawnTime;
    private GameObject playerObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Every x seconds, spawn a pirate ship nearby, maybe with some variance
        if (Time.time > lastSpawnTime + spawnInterval)
        {
            SpawnChest();
            SpawnChest();
            SpawnChest();
            lastSpawnTime = Time.time;
        }
    }

    public void SpawnChest()
    {
        {
            playerObject.GetComponent<PlayerScript>().getPlayerPosition();

            // Generate a position for the enemy to spawn at
            Vector2 newPiratePosition = GenerateStartPosition();
            Vector3 positionTranslation = new(newPiratePosition.x, newPiratePosition.y, 0);

            // Spawn the pirate
            Instantiate(chestPrefab, positionTranslation, new(0, 0, 0, 0), gameObject.transform);
        }
    }

    private Vector2 GenerateStartPosition()
    {
        Vector2 playerPosition = playerObject.transform.position;

        float randomRadius = Random.Range(150, 300) / 10f;
        float bearing = Random.Range(0, 360);

        // Find the components of the triangle formed when generating a random radius
        // and random angle to offset the new pirate object by
        float xOffset = (bearing <= 180) ? (randomRadius * Mathf.Cos(bearing % 90)) : -(randomRadius * Mathf.Cos(bearing % 90));
        float yOffset = (bearing <= 90 || bearing >= 270) ? (randomRadius * Mathf.Sin(bearing % 90)) : -(randomRadius * Mathf.Sin(bearing % 90));

        Vector2 spawnPosition = new Vector2(playerPosition.x + xOffset, playerPosition.y + yOffset);

        return spawnPosition;
    }


    public void UpdateGold(int gold)
    {
        playerGold = playerGold + gold;
    }
}
