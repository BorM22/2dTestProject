using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class enemyBS_Animator : MonoBehaviour
{
    public Animator animator;
    public enemyController _enemyController; 
    public bsAttackPlayerScript _bsAttack; 
    characterStats _charactStats; 

    void Start()
    {
        animator = GetComponent<Animator>();
        _enemyController = GetComponentInParent<enemyController>();
        _bsAttack = GetComponentInParent<bsAttackPlayerScript>();
        _charactStats = GetComponentInParent<characterStats>(); 
    }

    void Update()
    {
        SetMoveAnimationBS();
        SetAttackAnimationBS();
        
    }

    public void SetMoveAnimationBS()
    {
        if (_enemyController._isMoveBS == true && this.gameObject == _enemyController.Enemy_1)
        {
            animator.SetBool("isMoveBS", true);
        }
        else
        {
            animator.SetBool("isMoveBS", false);
        }
    }

    public void SetAttackAnimationBS()
    {
        if (_bsAttack.isAttacking == true && this.gameObject == _enemyController.Enemy_1)
        {
            animator.SetBool("isAttackBS", true);
        }
        else
        {
            animator.SetBool("isAttackBS", false);
        }
    }

   

    
}
