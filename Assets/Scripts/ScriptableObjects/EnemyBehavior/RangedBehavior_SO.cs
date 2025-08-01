using UnityEngine;

[CreateAssetMenu(fileName = "RangedBehavior_SO", menuName = "Scriptable Objects/EnemyBehavior_SO/RangedBehavior_SO")]
public class RangedBehavior_SO : EnemyBehavior_SO
{
    [SerializeField] Projectile _projectilePrefab;
    public override void EnemyBehavior(Unit target, Unit usedEnemy)
    {
        var enemy = ((Enemy)usedEnemy);
        if (enemy.attackReady)
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
    
    private bool IsInRange(Unit target, Unit usedEnemy)
    { 
        float distance = Vector2.Distance(usedEnemy.transform.position,usedEnemy.transform.position);
        if (distance < ((Enemy)usedEnemy).range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    private void Attack(Unit target, Unit usedEnemy)
    {
        ((Enemy)usedEnemy).attackReady = false;
        Vector3 shootPosition = target.transform.position;
        Projectile spawnedProjectile = Instantiate(_projectilePrefab);
        spawnedProjectile.transform.position = usedEnemy.transform.position;
        spawnedProjectile.transform.up = -(usedEnemy.transform.position - shootPosition);
    }

}
