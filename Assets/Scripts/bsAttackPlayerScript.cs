using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bsAttackPlayerScript : MonoBehaviour
{
    playerStats _playerStats;
    public bool isAttacking = false;
    public bool isPlayerInRange = false;
    characterStats _charactStats;
    
    

    void Start()
{
    GameObject player = GameObject.Find("Player");
    _playerStats = player.GetComponent<playerStats>();
    _charactStats = player.GetComponent<characterStats>();
}

   private void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.collider.CompareTag("Player"))
    {
        isPlayerInRange = true;
        if (!isAttacking)
        {
            StartCoroutine(AttackPlayer());
        }
    }
}

private void OnCollisionExit2D(Collision2D collision)
{
    if(collision.collider.CompareTag("Player"))
    {
        isPlayerInRange = false;
    }
}


    IEnumerator AttackPlayer()
    {
        isAttacking = true;
       
        while(isPlayerInRange)
        {
            yield return new WaitForSeconds(0.5f);
            AttackDamage();
            
        }
        isAttacking = false;
        
    }

    void AttackDamage()
{
    if(isPlayerInRange)
    {
        _playerStats.TakeDamage(1);
    }
}

}
