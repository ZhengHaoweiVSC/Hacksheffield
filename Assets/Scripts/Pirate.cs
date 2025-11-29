using System.CodeDom.Compiler;
using Unity.VisualScripting;
using UnityEngine;

public class Pirate : MonoBehaviour 
{
    private Vector2 piratePosition;
    GameObject playerObject;
    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    private float getDistanceToPlayer()
    {
        Vector2 playerPos = playerObject.transform.position;
        Vector2 myPosition = transform.position;

        float distance = Vector2.Distance(playerPos, myPosition);

        return distance;
    }

}
