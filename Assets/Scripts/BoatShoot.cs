using UnityEngine;
using UnityEngine.InputSystem;

public class BoatShoot : MonoBehaviour
{
    [Header("Projectile Settings (Up to 5 Types)")]
    public GameObject[] projectilePrefabs;

    [Header("Where Projectiles Come From")]
    public Transform leftShootPoint;
    public Transform leftShootPoint2;   // NEW
    public Transform rightShootPoint;
    public Transform rightShootPoint2;  // NEW

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

        if (Time.time < nextShootTime) return;

        // Left Side (Q)
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            FireLeft();
            nextShootTime = Time.time + stats.cooldown;
        }

        // Right Side (E)
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            FireRight();
            nextShootTime = Time.time + stats.cooldown;
        }
    }

    // -------------------------------------------------
    // Fire LEFT side
    // -------------------------------------------------
    private void FireLeft()
    {
        ShootProjectile(leftShootPoint);

        if (stats.hasDoubleShot)
            ShootProjectile(leftShootPoint2);
    }

    // -------------------------------------------------
    // Fire RIGHT side
    // -------------------------------------------------
    private void FireRight()
    {
        ShootProjectile(rightShootPoint);

        if (stats.hasDoubleShot)
            ShootProjectile(rightShootPoint2);
    }

    // -------------------------------------------------
    // MAIN SHOOT FUNCTION
    // -------------------------------------------------
    private void ShootProjectile(Transform shootPoint)
    {
        if (projectilePrefabs.Length == 0 || shootPoint == null)
            return;

        int prefabIndex = Random.Range(0, projectilePrefabs.Length);

        GameObject proj = Instantiate(
            projectilePrefabs[prefabIndex],
            shootPoint.position,
            shootPoint.rotation
        );

        // Scale upgrade
        proj.transform.localScale *= stats.cannonSizeMultiplier;

        // Velocity
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.linearVelocity = shootPoint.right * stats.projectileSpeed;

        // Hitbox scaling
        CircleCollider2D col = proj.GetComponent<CircleCollider2D>();
        if (col != null)
            col.radius *= stats.cannonSizeMultiplier;

        // Enemy handling
        ProjectileHandler handler = proj.AddComponent<ProjectileHandler>();
        handler.destroyableEnemyTags = destroyableEnemyTags;

        Destroy(proj, stats.projectileLifetime);
    }
}