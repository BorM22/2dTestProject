using System.Collections;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public Transform target;
    public GameObject Enemy_1;
    public GameObject Enemy_2;
    private characterStats stats1;
    private characterStats stats2;
    public float separationRadius = 1.0f;
    public bool _isMoveBA = false;
    public bool _isMoveBS = false;

    void Start()
    {
        stats1 = Enemy_1.GetComponent<characterStats>();
        stats2 = Enemy_2.GetComponent<characterStats>();
        stats1.health = 1;
        stats2.health = 2;
    }

    void Update()
    {
        MoveTowardsTarget(Enemy_1, stats1);
        MoveTowardsTarget(Enemy_2, stats2);
    }

    void MoveTowardsTarget(GameObject enemy, characterStats stats)
    {
        bsAttackPlayerScript bsAttackScript = enemy.GetComponent<bsAttackPlayerScript>();
        baAttackPlayerScript baAttackScript = enemy.GetComponent<baAttackPlayerScript>();

        if (bsAttackScript != null && bsAttackScript.isPlayerInRange)
        {
            return;
        }

        if (baAttackScript != null && baAttackScript.isPlayerInRangeBA)
        {
            return;
        }

        Vector2 moveDirection = (target.position - enemy.transform.position).normalized;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.transform.position, separationRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != enemy && (collider.CompareTag("Enemy")))
            {
                _isMoveBA = false;
                _isMoveBS = false;
                return;
            }
        }

        _isMoveBA = true;
        _isMoveBS = true;
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, target.position, stats.speed * Time.deltaTime);
    }
}
