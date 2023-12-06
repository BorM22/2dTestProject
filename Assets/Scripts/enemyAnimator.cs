using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class enemyAnimator : MonoBehaviour
{
    public Animator animator;
    public enemyController _enemyController; 
    public baAttackPlayerScript _baAttack; 
    characterStats _charactStats; 

    void Start()
    {
        animator = GetComponent<Animator>();
        _enemyController = GetComponent<enemyController>();
        _baAttack = GetComponentInParent<baAttackPlayerScript>();
        _charactStats = GetComponentInParent<characterStats>(); 
    }

    void Update()
    {
        SetMoveAnimation();
        SetAttackBAAnimation();
    }

    public void SetMoveAnimation()
    {
        if(_enemyController._isMoveBA == true && this.gameObject == _enemyController.Enemy_2)
        {
        animator.SetBool("isMoveBA", true);
        }
        else{
            animator.SetBool("isMoveBA", false);
        }
    }

     public void SetAttackBAAnimation()
    {
        if(_baAttack.isAttackingBA == true && this.gameObject == _enemyController.Enemy_2)
        {
            animator.SetBool("isAttackBA", true);
        }
        else{
            animator.SetBool("isAttackBA", false);
        }
    }
}
