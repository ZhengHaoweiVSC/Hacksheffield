using UnityEngine;

public class Barrier : MonoBehaviour
{
    public float radius = 2.5f;
    public float duration = 30f;

    private float timer;
    private bool active = false;
    private Transform player;

    private void OnEnable()
    {
        // ATTACH TO PLAYER ALWAYS
        if (transform.parent == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            transform.SetParent(player);
            transform.localPosition = Vector3.zero;
        }
        else
        {
            player = transform.parent;
        }

        timer = duration;
        active = true;
    }

    private void Update()
    {
        if (!active) return;

        transform.position = player.position;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            gameObject.SetActive(false);
            active = false;
        }
    }

    public void RefreshBarrier()
    {
        timer = duration;
        active = true;
        gameObject.SetActive(true);

        // Make sure it's attached
        if (transform.parent == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            transform.SetParent(player);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
            Destroy(col.gameObject);
    }
}