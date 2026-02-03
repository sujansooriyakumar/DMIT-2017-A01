using UnityEngine;

public class RangedEnemy : Enemy
{
    public override void Attack()
    {
        // instantiate a projectile
        // give the projectile a direction + velocity
        // projectile handles collisions 
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void Patrol()
    {
        throw new System.NotImplementedException();
    }

    public override void Pursue()
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage(float dmg_)
    {
        throw new System.NotImplementedException();
    }

   
}
