using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("MainScene");
    }
}
