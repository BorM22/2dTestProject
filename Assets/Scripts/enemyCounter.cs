using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemyCounter : MonoBehaviour
{
    public TextMeshProUGUI enemyCountText;

    void Start()
    {
        UpdateEnemyCountText();
    }

    public void IncrementEnemyCount()
    {
        GameManager.instance.IncrementEnemyCount();
        UpdateEnemyCountText();
    }

     void UpdateEnemyCountText()
    {
        if (enemyCountText != null)
        {
            enemyCountText.text = "Enemy Kills: " + GameManager.instance.GetEnemyCount().ToString();
        }
    }
}
