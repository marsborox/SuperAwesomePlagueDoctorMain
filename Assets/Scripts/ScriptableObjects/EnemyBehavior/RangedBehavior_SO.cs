using UnityEngine;

[CreateAssetMenu(fileName = "RangedBehavior_SO", menuName = "Scriptable Objects/EnemyBehavior_SO/RangedBehavior_SO")]
public class RangedBehavior_SO : EnemyBehavior_SO
{
    [SerializeField] Projectile _projectilePrefab;
    public override void EnemyBehavior(Player target, Enemy usedEnemy)
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
    
    private bool IsInRange(Player target, Enemy usedEnemy)
    { 
        float distance = Vector2.Distance(usedEnemy.transform.position,usedEnemy.transform.position);
        if (distance < usedEnemy.range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Attack(Player target,Enemy usedEnemy)
    {
        Instantiate(_projectilePrefab/*,usedEnemy.transform.position*/);
    }
}
