using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerStats : MonoBehaviour
{
    public int health;
    public int speed;
    public int damage;


    void Start()
    {
        
    }
     public void TakeDamage(int damage)
    {
       
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }


     void Die()
    {
        SceneManager.LoadScene("gameOverScene");
        Destroy(gameObject);
        
    }
}
