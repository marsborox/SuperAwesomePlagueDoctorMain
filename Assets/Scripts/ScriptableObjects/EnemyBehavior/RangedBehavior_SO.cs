using UnityEngine;

[CreateAssetMenu(fileName = "RangedBehavior_SO", menuName = "Scriptable Objects/EnemyBehavior_SO/RangedBehavior_SO")]
public class RangedBehavior_SO : EnemyBehavior_SO
{
    [SerializeField] Projectile _projectilePrefab;
    [Tooltip("rangedAttackPattern")]
    [SerializeField] Weapon_SO _rangedWeapon;
    public override void EnemyBehavior(Unit target, Unit usedEnemy)
    {
        var enemy = ((Enemy)usedEnemy);
        if (enemy.attackReady)
        {        
            if (IsInRange(target, usedEnemy))
            {
                if (_rangedWeapon == null)
                {
                    Attack(target, usedEnemy);
                }
                else
                {
                    Transform attackDirection;
                    
                    ((Enemy)usedEnemy).attackReady = false;

                    Vector2 targetPosition = (usedEnemy.transform.position -target.transform.position).normalized;
                    Quaternion shootingDirection;/* = Quaternion.Euler(targetPosition.x,targetPosition.y,targetPosition.z);*/
                    //Transform shootingTransform = usedEnemy.transform;
                    shootingDirection = Quaternion.LookRotation(targetPosition);
                    //shootingTransform.rotation = shootingDirection;
                    _rangedWeapon.Attack(_projectilePrefab,usedEnemy, /*shootingDirection*/target.transform);
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
    {
        ((Enemy)usedEnemy).attackReady = false;
        Vector3 shootPosition = target.transform.position;
        Projectile spawnedProjectile = Instantiate(_projectilePrefab);
        spawnedProjectile.transform.position = usedEnemy.transform.position;
        spawnedProjectile.transform.up = -(usedEnemy.transform.position - shootPosition);
        spawnedProjectile.targetTag = ((Enemy)usedEnemy).targetTag;
        spawnedProjectile.damage = ((Enemy)usedEnemy).damage;
    }
    private void AttackFromSO()
    { 
        
    }
}
