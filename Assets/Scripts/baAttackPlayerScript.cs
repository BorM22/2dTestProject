using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baAttackPlayerScript : MonoBehaviour
{
    playerStats _playerStats;
    public bool isAttackingBA = false;
    public bool isPlayerInRangeBA = false;
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
        isPlayerInRangeBA = true;
        if (!isAttackingBA)
        {
            StartCoroutine(AttackPlayer());
        }
    }
}

private void OnCollisionExit2D(Collision2D collision)
{
    if(collision.collider.CompareTag("Player"))
    {
        isPlayerInRangeBA = false;
    }
}


  IEnumerator AttackPlayer()
{
    while (isPlayerInRangeBA)
    {
        isAttackingBA = true;
        yield return new WaitForSeconds(0.5f); 
        AttackDamage();
        isAttackingBA = false;
        yield return new WaitForSeconds(0.5f); 
    }
}



    void AttackDamage()
{
    if(isPlayerInRangeBA)
    {
        _playerStats.TakeDamage(1);
        
    }
}

}
