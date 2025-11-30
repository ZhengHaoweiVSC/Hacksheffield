using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int maxPlayerHealth = 3;
    private int currentPlayerHealth;

    private void Start()
    {
        currentPlayerHealth = 3;
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
    }

    private void Die()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("GameOverScreen");
    }
}
