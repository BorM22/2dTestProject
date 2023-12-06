using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public static bool resetCount = false;

    public void RestartGame()
    {

        
        resetCount = true;
        SceneManager.LoadScene("firstScene");
        
    }
}
