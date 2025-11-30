using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed = 5f;
    public float moveSpeedIncreaseAmount = 1f;

    [Header("Shooting Stats")]
    public float projectileSpeed = 15f;
    public float cooldown = 0.3f;

    public float projectileSpeedIncrease = 3f;
    public float cooldownReduction = 0.05f;

    [Header("Projectile Settings")]
    public float projectileLifetime = 2f;

    public void UpgradeMoveSpeed()
    {
        moveSpeed += moveSpeedIncreaseAmount;
    }

    public void UpgradeProjectileSpeed()
    {
        projectileSpeed += projectileSpeedIncrease;
    }

    public void ReduceCooldown()
    {
        cooldown = Mathf.Max(0.05f, cooldown - cooldownReduction);
    }
}