using UnityEngine;


[CreateAssetMenu(fileName = "MeleeBehavior_SO", menuName = "Scriptable Objects/EnemyBehavior_SO/MeleeBehavior_SO")]
public class MeleeBehavior_SO : EnemyBehavior_SO, I_MeleeAttack
{
    public override void EnemyBehavior(Unit target, Unit usedEnemy)
    {
        //Debug.Log("Enemy is Behaving Melee");
        var enemy = ((Enemy)usedEnemy);
        if (enemy.isAttackReady)
        {
            if (IsInRange(target, usedEnemy))
            {

                //((I_MeleeAttack)this).Attack(target, usedEnemy);
                //Debug.Log("melee attacking from MeleeBehavior_SO");
                //((Enemy)usedEnemy).isAttackReady = false;

                //((I_MeleeAttack)this).MeleeAttack();
                ((I_MeleeAttack)this).MeleeAttack(target, usedEnemy);

                Debug.Log("melee attacking from MeleeBehavior_SO");
                /*
                ((Enemy)usedEnemy).isAttackReady = false;

                target.TakeDamage(usedEnemy.ReturnDamageAmount());
                usedEnemy.Attack();
                */
            }
            else
            {
                MoveToTarget(target, usedEnemy);
            }
        }
    }

}
