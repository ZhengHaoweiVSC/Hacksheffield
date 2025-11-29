using UnityEngine;
using UnityEngine.InputSystem;

public class BoatShoot : MonoBehaviour
{
    [Header("Projectile Settings (Up to 5)")]
    public GameObject[] projectilePrefabs;

    [Header("Where Projectiles Come From")]
    public Transform leftShootPoint;   
    public Transform rightShootPoint;

    [Header("Enemy Tags This Projectile Can Destroy")]
    public string[] destroyableEnemyTags;

    [Header("Shoot Settings")]
    public float projectileSpeed = 15f;
    public float projectileLifetime = 2f;   
    public float shootCooldown = 0.3f;      

    private float nextShootTime = 0f;

    private void Update()
    {
        if (Keyboard.current == null) return;

        if (Time.time < nextShootTime) return;

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            ShootProjectile(leftShootPoint);
            nextShootTime = Time.time + shootCooldown;
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            ShootProjectile(rightShootPoint);
            nextShootTime = Time.time + shootCooldown;
        }
    }

    private void ShootProjectile(Transform shootPoint)
    {
        int index = Random.Range(0, projectilePrefabs.Length);

        GameObject proj = Instantiate(projectilePrefabs[index], shootPoint.position, shootPoint.rotation);

        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // IMPORTANT:
            // local direction so it always shoots correctly even when rotating
            rb.linearVelocity = shootPoint.right * projectileSpeed;
        }

        ProjectileHandler handler = proj.AddComponent<ProjectileHandler>();
        handler.destroyableEnemyTags = destroyableEnemyTags;

        // Destroy projectile after X seconds
        Destroy(proj, projectileLifetime);
    }
}