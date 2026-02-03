using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public string enemyName;
    
    public int HP;
    public int ATK;
    public int DEF;

    public float attackDelay;

    public CircleOverlap sightline;
    public CircleOverlap attackRange;

    public abstract void Patrol();
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
        StartCoroutine(AttackCoroutine());
    }
    public IEnumerator AttackCoroutine()
    {
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(attackDelay);
        }
        yield return null;
    }

}
