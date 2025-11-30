using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UpgradeUI : MonoBehaviour
{
    public static UpgradeUI Instance;

    public GameObject panel;

    [Header("Three Button Slots")]
    public Button[] optionButtons;         // size = 3
    public TextMeshProUGUI[] optionLabels; // size = 3

    private PlayerStats currentPlayer;

    private void Awake()
    {
        Instance = this;
    }

    public void Open(PlayerStats player)
    {
        currentPlayer = player;

        ShowRandomUpgrades();

        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Close()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

    // -------------------------------------------------------------------
    //     SHOWING THREE RANDOM UPGRADES
    // -------------------------------------------------------------------
    public void ShowRandomUpgrades()
    {
        // List all possible upgrades
        List<UpgradeType> available = new List<UpgradeType>()
        {
            UpgradeType.MoveSpeed,
            UpgradeType.ProjectileSpeed,
            UpgradeType.Cooldown,

            UpgradeType.Barrier,
            UpgradeType.DoubleShot,
            UpgradeType.RandomizeStats,
            UpgradeType.BigCannon
        };

        // Remove hidden NPC detector if already used
        if (!currentPlayer.hasHiddenNpcDetector)
            available.Add(UpgradeType.HiddenNPC);

        // Shuffle list
        for (int i = 0; i < available.Count; i++)
        {
            int rand = Random.Range(0, available.Count);
            (available[i], available[rand]) = (available[rand], available[i]);
        }

        // Pick first 3 upgrades
        UpgradeType[] chosen = new UpgradeType[3];
        for (int i = 0; i < 3; i++)
            chosen[i] = available[i];

        // Randomize button placement
        List<int> slotIndices = new List<int>() { 0, 1, 2 };
        for (int i = 0; i < slotIndices.Count; i++)
        {
            int rand = Random.Range(0, slotIndices.Count);
            (slotIndices[i], slotIndices[rand]) = (slotIndices[rand], slotIndices[i]);
        }

        // Assign upgrades to random button slots
        for (int i = 0; i < 3; i++)
        {
            int slot = slotIndices[i];

            optionLabels[slot].text = chosen[i].ToString();
            AssignButtonAction(optionButtons[slot], chosen[i]);
        }
    }

    // -------------------------------------------------------------------
    //     BUTTON ACTION ASSIGNMENT
    // -------------------------------------------------------------------
    private void AssignButtonAction(Button btn, UpgradeType upgrade)
    {
        btn.onClick.RemoveAllListeners();

        btn.onClick.AddListener(() =>
        {
            ApplyUpgrade(upgrade);
            Close();
        });
    }

    // -------------------------------------------------------------------
    //     APPLYING UPGRADES
    // -------------------------------------------------------------------
    private void ApplyUpgrade(UpgradeType type)
    {
        switch (type)
        {
            case UpgradeType.MoveSpeed: currentPlayer.UpgradeMoveSpeed(); break;
            case UpgradeType.ProjectileSpeed: currentPlayer.UpgradeProjectileSpeed(); break;
            case UpgradeType.Cooldown: currentPlayer.ReduceCooldown(); break;

            case UpgradeType.Barrier: currentPlayer.ActivateBarrier(); break;
            case UpgradeType.DoubleShot: currentPlayer.EnableDoubleShot(); break;
            case UpgradeType.HiddenNPC: currentPlayer.UnlockNpcDetector(); break;
            case UpgradeType.RandomizeStats: currentPlayer.RandomizeStats(); break;
            case UpgradeType.BigCannon: currentPlayer.UpgradeBigCannon(); break;
        }
    }
}

// -------------------------------------------------------------------
//     ALL UPGRADE TYPES
// -------------------------------------------------------------------
public enum UpgradeType
{
    MoveSpeed,
    ProjectileSpeed,
    Cooldown,

    Barrier,
    DoubleShot,
    HiddenNPC,
    RandomizeStats,
    BigCannon
}