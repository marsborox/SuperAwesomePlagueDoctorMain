using UnityEngine;


[CreateAssetMenu(fileName = "MeleeBehavior_SO", menuName = "Scriptable Objects/EnemyBehavior_SO/MeleeBehavior_SO")]
public class MeleeBehavior_SO : EnemyBehavior_SO
{
    public override void EnemyBehavior(Unit target, Unit usedEnemy)
    {
        //Debug.Log("Enemy is Behaving Melee");
        var enemy = ((Enemy)usedEnemy);
        if (enemy.isAttackReady)
        {
            if (IsInRange(target, usedEnemy))
            {
                Attack(target, usedEnemy);

            }
            else
            {
                MoveToTarget(target, usedEnemy);
            }
        }
    }
    public override void Attack(Unit target, Unit usedEnemy)
    {
        Debug.Log("melee attacking");
        ((Enemy)usedEnemy).isAttackReady = false;
        target.TakeDamage(usedEnemy.ReturnDamageAmount());
        usedEnemy.Attack();
    }

}
