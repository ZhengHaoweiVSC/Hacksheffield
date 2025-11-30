using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Special Upgrades (Flags)")]
    public bool hasBarrier = false;
    public bool hasDoubleShot = false;
    public bool hasLuckyFind = false;        
    public bool hasRandomizeUpgrade = false;
    public bool hasBigCannon = false;

    // NEW — prevents double-application of the mega-buff
    public bool hasHiddenNpcSuperBuffApplied = false;

    [Header("Hidden NPC / Arrow (optional)")]
    public HiddenNPCSpirit hiddenNpcSpirit;  
    public HiddenNpcArrow npcArrow;          

    [Header("Big Cannon Settings")]
    public float cannonSizeMultiplier = 1f;
    public float bigCannonIncreaseAmount = 0.5f;

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

    // --------------------------------------------------------
    // SPECIAL UPGRADES
    // --------------------------------------------------------

    // 1. Barrier
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

    // 2. Double Shot
    public void EnableDoubleShot()
    {
        hasDoubleShot = true;
    }

    // 3. Lucky Find (1 in 10 chance to give 10x stats immediately)
    public void UnlockLuckyFind()
    {
        if (hasLuckyFind) return;

        hasLuckyFind = true;

        int roll = Random.Range(0, 10);
        Debug.Log($"LuckyFind roll: {roll} (success if 0)");

        if (roll == 0)
        {
            ApplyLuckyFindSuperBuff();
            Debug.Log("Lucky Find succeeded! 10x SUPER BUFF applied!");
        }
        else
        {
            Debug.Log("Lucky Find failed. No buff this time.");
        }
    }

    // NEW — Lucky Find super buff with safety check
    private void ApplyLuckyFindSuperBuff()
    {
        if (hasHiddenNpcSuperBuffApplied) return;

        moveSpeed *= 10f;
        projectileSpeed *= 10f;
        cannonSizeMultiplier *= 10f;
        projectileLifetime *= 10f;

        cooldown = 0f;

        hasHiddenNpcSuperBuffApplied = true;
    }

    // NEW — Compatibility call for HiddenNPCSpirit
    public void ApplyHiddenNpcSuperBuffOnContact()
    {
        if (hasHiddenNpcSuperBuffApplied) return;

        ApplyLuckyFindSuperBuff();
        Debug.Log("ApplyHiddenNpcSuperBuffOnContact called — compatibility buff applied.");
    }

    // 4. Randomize Stats
    public void RandomizeStats()
    {
        float randomFactor = Random.Range(0.5f, 3f);

        moveSpeed *= randomFactor;
        projectileSpeed *= randomFactor;
        cannonSizeMultiplier *= randomFactor;
        cooldown *= Random.Range(0.4f, 1.5f);
        cooldown = Mathf.Max(0.05f, cooldown);

        hasRandomizeUpgrade = true;
    }

    // 5. Big Cannon Buff
    public void UpgradeBigCannon()
    {
        cannonSizeMultiplier += bigCannonIncreaseAmount;
        hasBigCannon = true;
    }

    // --------------------------------------------------------
    // BASE UPGRADES
    // --------------------------------------------------------

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