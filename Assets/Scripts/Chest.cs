using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour
{
    private Vector2 chestPosition;
    private ChestScript chestScript;
    private int goldAmount;
    private float timeToLive;
    private bool isCollected;

    public Sprite closedChestSprite;
    public Sprite openedChestSprite;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        chestScript = GameObject.FindGameObjectWithTag("ChestScript").GetComponent<ChestScript>();
        goldAmount = Random.Range(1, 10);
        timeToLive = Time.time + 20.0f;
        isCollected = false;

        spriteRenderer.sprite = closedChestSprite;
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
        
        spriteRenderer.sprite = openedChestSprite;
        chestScript.UpdateGold(goldAmount);
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

        var keyboard = Keyboard.current;

        if (GetDistanceToPlayer() < 2 && !isCollected && keyboard.tabKey.isPressed)
        {
            CollectChest();
        }
    }
}
