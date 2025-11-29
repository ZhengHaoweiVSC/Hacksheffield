using UnityEngine;

public class Chest : MonoBehaviour
{
    private Vector2 chestPosition;
    private ChestScript chestScript;
    private int goldAmount;
    private float timeToLive;
    private bool isCollected;

    void Start()
    {
        chestScript = GameObject.FindGameObjectWithTag("ChestScript").GetComponent<ChestScript>();
    }

    public Chest()
    {
        goldAmount = Random.Range(1, 10);
        timeToLive = Time.time + 120.0f;
        isCollected = false;
    }

    public Vector2 GetChestPosition()
    {
        return gameObject.transform.position;
    }

    public int GetGoldAmount()
    {
        return goldAmount;
    }
    public bool IsCollected()
    {
        return isCollected;
    }
    public void CollectChest()
    {
        isCollected = true;
    }

    public float GetDistanceToPlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        return Vector2.Distance(GetChestPosition(), playerObject.transform.position);
    }

    void Update()
    {
        if (Time.time > timeToLive)
        {
            Destroy(gameObject);
        }

        if (GetDistanceToPlayer() < 1 && !isCollected)
        {
            CollectChest();
            isCollected = true;
            chestScript.UpdateGold(goldAmount);
        }
    }
}
