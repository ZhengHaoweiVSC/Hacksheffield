using System.CodeDom.Compiler;
using UnityEngine;

public class Pirate : MonoBehaviour 
{
    private Vector2 piratePosition;

    public Pirate()
    {
        
    }

    public Vector2 GetPiratePosition()
    {
        return piratePosition;
    }

    //private Vector2 generateStartPosition()
    //{
    //    Vector2 playerPosition = new Vector2();


    //    return new int[] { generatedX, generatedY };
    //}


}
