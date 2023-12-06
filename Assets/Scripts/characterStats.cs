using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterStats : MonoBehaviour
{
    public int health;
    public int speed;
    public int damage;
 

   

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
    enemyCounter _enemyCounter = FindObjectOfType<enemyCounter>();
    if (_enemyCounter != null)
    {
        _enemyCounter.IncrementEnemyCount();
    }
        Destroy(gameObject);
    }
}
