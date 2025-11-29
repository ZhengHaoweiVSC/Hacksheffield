using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private int playerGold;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnChest();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnChest()
    {
        Vector2 newChestPosition = new(Random.Range(-10, 10), Random.Range(-10, 10));
        Instantiate(Resources.Load("Prefabs/Chest"), newChestPosition, Quaternion.identity, transform);
    }

    public void UpdateGold(int gold)
    {
        playerGold = playerGold + gold;
    }
}
