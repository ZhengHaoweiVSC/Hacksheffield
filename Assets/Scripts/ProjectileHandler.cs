using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{
    public string[] destroyableEnemyTags;

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (string tag in destroyableEnemyTags)
        {
            if (other.CompareTag(tag))
            {
                Destroy(other.gameObject); // destroy enemy
                Destroy(gameObject);       // destroy projectile
                return;
            }
        }
    }
}