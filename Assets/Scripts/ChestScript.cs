using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private int playerGold;
    public GameObject chestPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //SpawnChest();
    }

    public void SpawnChest()
    {
        Vector2 newChestPosition = new(Random.Range(-10, 10), Random.Range(-10, 10));
        Instantiate(chestPrefab, newChestPosition, Quaternion.identity, transform);
    }

    public void UpdateGold(int gold)
    {
        playerGold = playerGold + gold;
    }
}
