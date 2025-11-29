using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public static UpgradeUI Instance;
    private PlayerStats currentPlayer;

    private void Awake()
    {
        Instance = this;
    }

    public void Open(PlayerStats player)
    {
        currentPlayer = player;

        gameObject.SetActive(true);
        Time.timeScale = 0f;  
    }

    public void Close()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void UpgradeMovement()
    {
        currentPlayer.UpgradeMoveSpeed();
        Close();
    }

    public void UpgradeProjectileSpeed()
    {
        currentPlayer.UpgradeProjectileSpeed();
        Close();
    }

    public void UpgradeCooldown()
    {
        currentPlayer.ReduceCooldown();
        Close();
    }
}