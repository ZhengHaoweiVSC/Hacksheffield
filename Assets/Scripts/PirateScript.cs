using UnityEngine;

public class PirateScript : MonoBehaviour
{
    GameObject playerObject;
    public GameObject piratePrefab;

    public void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        // 
    }

    public void spawnPirate()
    {
        playerObject.GetComponent<PlayerScript>().getPlayerPosition();

        // Generate a position for the enemy to spawn at
        Vector2 newPiratePosition = new(Random.Range(-10, 10), Random.Range(-10, 10));

    }


}