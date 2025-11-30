using System.CodeDom.Compiler;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Pirate : MonoBehaviour 
{
    private Vector2 piratePosition;
    GameObject playerObject;
    private float timeSinceLastAttack;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        timeSinceLastAttack = Time.time;
    }

    private void Update()
    {
        Vector2 playerPosition = playerObject.transform.position;
        float distanceToPlayer = getDistanceToPlayer(playerPosition);

        if (distanceToPlayer > 2.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, 0.8f*Time.deltaTime*(1 + (Time.time)) );
            OrientToPlayer(playerPosition);
        }
        else
        {
            playerObject.GetComponent<PlayerScript>().GetAttacked();
            Destroy(gameObject);
        }

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
