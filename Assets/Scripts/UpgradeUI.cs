using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public static UpgradeUI Instance;
    public GameObject panel;

    private PlayerStats currentPlayer;

    private void Awake()
    {
        Instance = this;
    }

    public void Open(PlayerStats player)
    {
        currentPlayer = player;

        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Close()
    {
        panel.SetActive(false);
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