using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Special Upgrades (Flags)")]
    public bool hasBarrier = false;
    public bool hasDoubleShot = false;
    public bool hasHiddenNpcDetector = false;
    public bool hasRandomizeUpgrade = false;
    public bool hasBigCannon = false;

    [Header("Big Cannon Settings")]
    public float cannonSizeMultiplier = 1f;
    public float bigCannonIncreaseAmount = 0.5f; // Adjustable in Inspector

    public GameObject barrierPrefab;

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

    // -----------------------------
    // SPECIAL UPGRADES
    // -----------------------------

    // 1. One-time protective barrier
    public void ActivateBarrier()
    {
    Barrier existing = GetComponentInChildren<Barrier>(true);

    if (existing != null)
    {
        existing.RefreshBarrier();
    }
    else
    {
        GameObject barrierObj = Instantiate(barrierPrefab, transform);
        barrierObj.transform.localPosition = Vector3.zero;
    }
    }


    // 2. Double projectile shot
    public void EnableDoubleShot()
    {
        hasDoubleShot = true;
    }

    // 3. Hidden NPC detector (only once)
    public void UnlockNpcDetector()
    {
        hasHiddenNpcDetector = true;
    }

   public void RandomizeStats()
    {
    float randomFactor = Random.Range(0.5f, 3f);

    // Randomize main stats
    moveSpeed *= randomFactor;
    projectileSpeed *= randomFactor;
    cannonSizeMultiplier *= randomFactor;

    // Cooldown is special: only between 40%–150% of current value
    cooldown *= Random.Range(0.4f, 1.5f);
    cooldown = Mathf.Max(0.05f, cooldown); // Never below minimum

    hasRandomizeUpgrade = true;
    }



    // 5. Bigger cannonballs & hitboxes
    public void UpgradeBigCannon()
    {
        cannonSizeMultiplier += bigCannonIncreaseAmount;
        hasBigCannon = true;
    }

    // -----------------------------
    // BASE UPGRADES
    // -----------------------------

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