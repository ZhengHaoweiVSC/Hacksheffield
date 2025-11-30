using UnityEngine;

public class HiddenNPCSpirit : MonoBehaviour
{
    public bool isDiscovered = false;
    public PlayerStats player; // Drag player here

    private void Start()
    {
        gameObject.SetActive(false); // start hidden
    }

    public void Reveal()
    {
        if (isDiscovered) return;

        isDiscovered = true;
        gameObject.SetActive(true);

        // Hide arrow when NPC becomes visible
        if (player != null && player.npcArrow != null)
            player.npcArrow.gameObject.SetActive(false);

        Debug.Log("Hidden NPC Revealed!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (player != null)
                player.ApplyHiddenNpcSuperBuffOnContact();
        }
    }
}