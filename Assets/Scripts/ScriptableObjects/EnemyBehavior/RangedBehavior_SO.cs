using UnityEngine;

[CreateAssetMenu(fileName = "RangedBehavior_SO", menuName = "Scriptable Objects/EnemyBehavior_SO/RangedBehavior_SO")]
public class RangedBehavior_SO : EnemyBehavior_SO
{
    public override void EnemyBehavior(Player target, Enemy usedEnemy)
    {
        if (IsInRange(target, usedEnemy))
        {
            Attack();
        }
        else
        {
            MoveToTarget(target, usedEnemy);
        }
    }
    
    private void Attack()
    {
        Debug.Log("Shooting bam bam");
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
}
