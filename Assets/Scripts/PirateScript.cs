using Unity.VisualScripting; 
using UnityEngine;

public class PirateScript : MonoBehaviour
{
    GameObject playerObject;
    public GameObject piratePrefab;
    public float spawnInterval = 5f;
    private float lastSpawnTime;

    public void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        lastSpawnTime = Time.time + 3f;
    }

    public void Update()
    {
        // Every x seconds, spawn a pirate ship nearby, maybe with some variance
        if (Time.time > lastSpawnTime + spawnInterval)
        {
            SpawnPirate();
            lastSpawnTime = Time.time;
        }
    }

    public void SpawnPirate()
    {
        playerObject.GetComponent<PlayerScript>().getPlayerPosition();

        // Generate a position for the enemy to spawn at
        Vector2 newPiratePosition = GenerateStartPosition();
        Vector3 positionTranslation = new(newPiratePosition.x, newPiratePosition.y, 0);

        // Spawn the pirate
        Instantiate(piratePrefab, positionTranslation, new(0,0,0,0), gameObject.transform);
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




}