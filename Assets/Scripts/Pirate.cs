using System.CodeDom.Compiler;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using System.Threading;
using System.Collections;


public class Pirate : MonoBehaviour 
{
    private Vector2 piratePosition;
    GameObject playerObject;
    private float timeSinceLastAttack;
    public Sprite shipSprite;
    public Sprite boom1Sprite;
    public Sprite boom2Sprite;
    public Sprite boom3Sprite;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        timeSinceLastAttack = Time.time;
        spriteRenderer.sprite = shipSprite;
    }

    private void Update()
    {
        Vector2 playerPosition = playerObject.transform.position;
        float distanceToPlayer = getDistanceToPlayer(playerPosition);

        if (distanceToPlayer > 2.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, 1.5f*Time.deltaTime);
            OrientToPlayer(playerPosition);
        }
        else
        {
            playerObject.GetComponent<PlayerScript>().GetAttacked();
            spriteRenderer.sprite = boom1Sprite;

            
            spriteRenderer.sprite = boom2Sprite;
            time(1);
            spriteRenderer.sprite = boom3Sprite;
            time(1);
            Destroy(gameObject);
        }

    }

    IEnumerator time(float t)
    {
        yield return new WaitForSeconds(t);
    }

    private float getDistanceToPlayer(Vector2 playerPos)
    {
        playerPos = playerObject.transform.position;
        Vector2 myPosition = transform.position;

        float distance = Vector2.Distance(playerPos, myPosition);

        return distance;
    }

    private void OrientToPlayer(Vector2 playerPos)
    {
        Vector2 direction = playerPos - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
