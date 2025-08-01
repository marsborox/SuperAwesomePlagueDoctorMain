using UnityEngine;


[CreateAssetMenu(fileName = "MeleeBehavior_SO", menuName = "Scriptable Objects/EnemyBehavior_SO/MeleeBehavior_SO")]
public class MeleeBehavior_SO : EnemyBehavior_SO
{
    public override void EnemyBehavior(Unit target, Unit usedEnemy)
    {
        Debug.Log("Enemy is Behaving Melee");

        base.MoveToTarget(target,usedEnemy);
    }
}
