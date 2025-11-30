using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private int maxPlayerHealth = 3;
    private int currentPlayerHealth;
    public Canvas HUD;
    private GameObject[] heartsArray;

    private void Start()
    {
        currentPlayerHealth = 3;

        heartsArray = new GameObject[]
        {
            HUD.transform.GetChild(0).gameObject,
            HUD.transform.GetChild(1).gameObject,
            HUD.transform.GetChild(2).gameObject,
        };
    }

    private void Update()
    {
        if (currentPlayerHealth <= 0)
        {
            // Bad, player ded, die!
            Die();
        }
    }

    public Vector2 getPlayerPosition()
    {
        return gameObject.transform.position;
    }

    public void GetAttacked()
    {
        currentPlayerHealth -= 1;
        Destroy(heartsArray[currentPlayerHealth]);
        heartsArray[currentPlayerHealth] = null;
    }

    private void Die()
    {
        SceneManager.LoadScene("GameOverScreen");
    }
}
