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


            }
            else
            {
                MoveToTarget(target, usedEnemy);
            }
        }
    }
    public void Attack(Unit target, Unit usedEnemy)
    {
        ((Enemy)usedEnemy).isAttackReady = false;
    }

}
