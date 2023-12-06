using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerController : MonoBehaviour
{
    public Animator anim;
    public float rotationSpeed = 5f; 
    public float attackRadius = 0.5f; 
    public LayerMask enemyLayer;
    Quaternion rotatePlayer; 
    bool isRotatingLeft = false;
    bool isRotatingRight = false;
    private bool hasAttacked = false;


    void Start()
    {
        anim = GetComponent<Animator>();
        rotatePlayer = transform.rotation; 
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
             if (!hasAttacked)
            {
                anim.SetBool("isAttack", true);
                Attack();
                
                hasAttacked = true;
            }
        }

        else
        {
            anim.SetBool("isAttack", false);
            hasAttacked = false;
        }

        

        if (!isRotatingLeft && !isRotatingRight)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                isRotatingLeft = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                isRotatingRight = true;
            }
        }

        if (isRotatingLeft)
        {
            rotatePlayer = Quaternion.Euler(0, -180, 0);
            RotatePlayer();
        }
        if (isRotatingRight)
        {
            rotatePlayer = Quaternion.Euler(0, 0, 0);
            RotatePlayer();
        }
    }

    void RotatePlayer()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, rotatePlayer, Time.deltaTime * rotationSpeed);
        if (Quaternion.Angle(transform.rotation, rotatePlayer) < 0.01f)
        {
            transform.rotation = rotatePlayer;
            isRotatingLeft = false;
            isRotatingRight = false;
        }
    }

void Attack()
{
    Vector2 attackDirection = transform.right;


    
    if (isRotatingLeft)
    {
        attackDirection = -transform.right;
    }
    if(isRotatingRight)
    {
        attackDirection = transform.right;
    }

    RaycastHit2D hit = Physics2D.Raycast(transform.position, attackDirection, attackRadius, enemyLayer);

    
    if (hit.collider != null)
    {
        characterStats enemyStats = hit.collider.GetComponent<characterStats>();
        if (enemyStats != null)
        {
            enemyStats.TakeDamage(1);
        }
    }
}


}
