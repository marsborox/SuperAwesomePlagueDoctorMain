using UnityEngine;

[CreateAssetMenu(fileName = "SplitterBehavior_SO", menuName = "Scriptable Objects/EnemyBehavior_SO/SplitterBehavior_SO")]
public class SplitterBehavior_SO : EnemyBehavior_SO, I_MeleeAttack
{
    [SerializeField] private Enemy _miniMePrefab;
    [SerializeField] private int _amountOfMiniMeSpawns;
    [SerializeField] private Enemy_SO _miniMe_SO;
    public override void EnemyBehavior(Unit target, Unit usedEnemy)
    {
        //Debug.Log("Enemy is Behaving Melee");
        var enemy = ((Enemy)usedEnemy);
        if (enemy.isAttackReady)
        {
            if (IsInRange(target, usedEnemy))
            {
                ((I_MeleeAttack)this).Attack(target, usedEnemy);

            }
            else
            {
                MoveToTarget(target, usedEnemy);
            }
        }
    }

    public override void Die(Unit usedEnemy)
    {
        usedEnemy.enemySpawner.SpawnEnemy(_miniMe_SO, _miniMePrefab,usedEnemy.transform);
    }

}
