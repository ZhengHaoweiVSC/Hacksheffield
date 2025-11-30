using UnityEngine;

public class HiddenNpcArrow : MonoBehaviour
{
    public Transform target;   // Hidden NPC
    public Transform player;   // Player
    public float distanceScale = 0.4f;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    public void ActivateArrow(Transform npcTarget)
    {
        target = npcTarget;
        sr.enabled = true;
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (!sr.enabled || player == null || target == null)
            return;

        // Position arrow above player
        transform.position = player.position + new Vector3(0, 1.3f, 0);

        // Rotate toward NPC
        Vector3 dir = target.position - player.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Scale arrow based on distance
        float distance = Vector3.Distance(player.position, target.position);
        float scale = Mathf.Clamp(distance * distanceScale, .5f, 2f);
        transform.localScale = new Vector3(scale, scale, 1f);
    }
}