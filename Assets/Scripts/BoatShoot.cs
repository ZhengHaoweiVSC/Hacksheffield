using UnityEngine;
using UnityEngine.InputSystem;

public class BoatShoot : MonoBehaviour
{
    [Header("Projectile Settings (Up to 5 Types)")]
    public GameObject[] projectilePrefabs;

    [Header("Where Projectiles Come From")]
    public Transform leftShootPoint;
    public Transform rightShootPoint;

    [Header("Enemy Tags This Projectile Can Destroy")]
    public string[] destroyableEnemyTags;

    private float nextShootTime = 0f;
    private PlayerStats stats;

    private void Start()
    {
        stats = GetComponent<PlayerStats>();
        if (stats == null)
            Debug.LogError("PlayerStats component missing on player!");
    }

    private void Update()
    {
        if (Keyboard.current == null) return;

        // Check cooldown
        if (Time.time < nextShootTime) return;

        // Shoot left (Q)
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            ShootProjectile(leftShootPoint);
            nextShootTime = Time.time + stats.cooldown;
        }

        // Shoot right (E)
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            ShootProjectile(rightShootPoint);
            nextShootTime = Time.time + stats.cooldown;
        }
    }

    private void ShootProjectile(Transform shootPoint)
    {
        if (projectilePrefabs.Length == 0) return;

        // Random projectile type
        int index = Random.Range(0, projectilePrefabs.Length);

        GameObject proj = Instantiate(projectilePrefabs[index],
                                      shootPoint.position,
                                      shootPoint.rotation);

        // Apply Rigidbody velocity
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Shoot using shootPoint.right (works with rotation)
            rb.linearVelocity = shootPoint.right * stats.projectileSpeed;
        }

        // Add projectile handler (destroy enemies)
        ProjectileHandler handler = proj.AddComponent<ProjectileHandler>();
        handler.destroyableEnemyTags = destroyableEnemyTags;

        // Destroy projectile after lifetime
        Destroy(proj, stats.projectileLifetime);
    }
}