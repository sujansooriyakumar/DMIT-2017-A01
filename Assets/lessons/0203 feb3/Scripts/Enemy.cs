using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Combat Params")]
    public int HP;
    public int ATK;
    public int DEF;
    public float attackDelay;

    [Header("Behavior Ranges")]
    public CircleOverlap sightline;
    public CircleOverlap attackRange;

    private Vector2 playerPosition;
    public Vector2 patrolRange;
    private Coroutine attackCoroutine;

    private void Awake()
    {
        sightline.OnOverlap += SetPlayerPosition;
        attackRange.OnOverlap += SetPlayerPosition;
    }

    public void SetPlayerPosition(Vector2 pos_)
    {
        playerPosition = pos_;
    }
    public void Patrol()
    {

    }

    private IEnumerator PatrolCoroutine(Vector3 nextPos)
    {
        while(transform.position != nextPos)
        {
            yield return null;
        }
        yield return null;
    }
    public abstract void Attack();
    public abstract void TakeDamage(float dmg_);
    public abstract void Die();
    public abstract void Pursue();

    private void Update()
    {
        if (sightline.CircleOverlapCheck())
        {
            Pursue();
        }

        if (attackRange.CircleOverlapCheck())
        {
            StartAttackCoroutine();
        }
    }
    public void StartAttackCoroutine()
    {
        if(attackCoroutine == null) attackCoroutine = StartCoroutine(AttackCoroutine());
    }
    public IEnumerator AttackCoroutine()
    {
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(attackDelay);
        }
       // yield return null;
    }

}
