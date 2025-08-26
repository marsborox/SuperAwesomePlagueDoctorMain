using UnityEngine;

[CreateAssetMenu(fileName = "RangedBehavior_SO", menuName = "Scriptable Objects/EnemyBehavior_SO/RangedBehavior_SO")]
public class RangedBehavior_SO : EnemyBehavior_SO
{
    [SerializeField] Projectile _projectilePrefab;
    [Tooltip("rangedAttackPattern")]
    [SerializeField] private Action_SO _attackSO;
    public override void EnemyBehavior(Unit target, Unit usedEnemy)
    {
        var enemy = ((Enemy)usedEnemy);
        if (enemy.isAttackReady)
        {        
            if (IsInRange(target, usedEnemy))
            {
                if (_attackSO == null)
                {
                    Attack(target, usedEnemy);
                }
                else
                {
                    ((Enemy)usedEnemy).isAttackReady = false;
                    Vector3 targetPosition = (target.transform.position - usedEnemy.transform.position).normalized;
                    float angle = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg;
                    angle -= 90f;
                    //Quaternion shootingDirection;/* = Quaternion.Euler(targetPosition.x,targetPosition.y,targetPosition.z);*/
                    //Transform shootingTransform = usedEnemy.transform;
                    Quaternion shootingDirection = Quaternion.Euler(0,0,angle);
                    //shootingTransform.rotation = shootingDirection;
                    _attackSO.Attack(usedEnemy, target.transform, shootingDirection);
                }
            }
            else
            {
                MoveToTarget(target, usedEnemy);
            }
        }
    }
    
    private bool IsInRange(Unit target, Unit usedEnemy)
    { 
        float distance = Vector2.Distance(target.transform.position,usedEnemy.transform.position);
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
    {//this is just in case
        ((Enemy)usedEnemy).isAttackReady = false;
        Vector3 shootPosition = target.transform.position;
        Projectile spawnedProjectile = Instantiate(_projectilePrefab);
        spawnedProjectile.transform.position = usedEnemy.transform.position;
        spawnedProjectile.transform.up = -(usedEnemy.transform.position - shootPosition);
        spawnedProjectile.targetTag = ((Enemy)usedEnemy).targetTag;
        spawnedProjectile.damage = ((Enemy)usedEnemy).unitStats.damage;
        
    }
    private void AttackFromSO()
    { 
        
    }
}
