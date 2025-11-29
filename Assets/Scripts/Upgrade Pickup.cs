using UnityEngine;

public class UpgradePickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStats stats = collision.GetComponent<PlayerStats>();
        if (stats != null)
        {
            UpgradeUI.Instance.Open(stats);
            Destroy(gameObject);
        }
    }
}