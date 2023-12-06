using UnityEngine;
using TMPro;

public class EnemyCountDisplay : MonoBehaviour
{
    public TextMeshProUGUI enemyCountText;

    void Start()
    {
        int enemyCount = GameManager.instance.GetEnemyCount();

        UpdateEnemyCountText(enemyCount);
    }

    public void UpdateEnemyCountText(int count)
    {
        if (enemyCountText != null)
        {
            enemyCountText.text = "Enemy Kills: " + count.ToString();
        }
    }
}
