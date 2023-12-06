using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int enemyCount = 0;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (GameOverMenu.resetCount)
        {
            ResetEnemyCount();
            GameOverMenu.resetCount = false;
        }
    }

    public void IncrementEnemyCount()
    {
        enemyCount++;
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }

    public void ResetEnemyCount()
    {
        enemyCount = 0;
    }
}
