using UnityEngine;

[CreateAssetMenu(fileName = "SplitterBehavior_SO", menuName = "Scriptable Objects/EnemyBehavior_SO/SplitterBehavior_SO")]
public class SplitterBehavior_SO : EnemyBehavior_SO, I_MeleeAttack, I_RandomPointOnDistance
{
    [SerializeField] private Enemy _miniMePrefab;
    [SerializeField] private int _amountOfMiniMeSpawns;
    [SerializeField] private Enemy_SO _miniMe_SO;
    [SerializeField] private float _miniMeMaxSpawnDistance;
    public override void EnemyBehavior(Unit target, Unit usedEnemy)
    {
        //Debug.Log("Enemy is Behaving Melee");
        var enemy = ((Enemy)usedEnemy);
        if (enemy.isAttackReady)
        {
            if (IsInRange(target, usedEnemy))
            {//problem here with method - why?
                
                //Debug.Log("player in range");
                ((I_MeleeAttack)this).Attack(target, usedEnemy);
                //Debug.Log("should have attacked");
                //Debug.Log("melee attacking from SplitterBehavior_SO");
                //((Enemy)usedEnemy).isAttackReady = false;
                target.TakeDamage(usedEnemy.ReturnDamageAmount());
                usedEnemy.Attack();
            }
            else
            {
                MoveToTarget(target, usedEnemy);
            }
        }
    }
    /*public override void TouchedTarget(Unit usedEnemy)
    {
        Debug.Log("touched Target.SplitterBehavior_SO");
    }*/
    public override void Die(Unit usedEnemy)
    {
        for (int i = 0; i<_amountOfMiniMeSpawns; i++)
        {
            //Debug.Log("willWeGet any Log???");
            Transform transform = ((I_RandomPointOnDistance)this).ReturnRandomTransformOnDistance(usedEnemy.transform, _miniMeMaxSpawnDistance);
            usedEnemy.enemySpawner.SpawnEnemy(_miniMe_SO, _miniMePrefab, usedEnemy.transform);
        }
    }
}
