using UnityEngine;

public class Chest : MonoBehaviour
{
    private Vector2 chestPosition;
    private int goldAmount;

    public Chest()
    {
        goldAmount = Random.Range(1, 10);
    }

    public Vector2 GetChestPosition()
    {
        return chestPosition;
    }
}
