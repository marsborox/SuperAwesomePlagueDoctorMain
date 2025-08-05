

using UnityEngine;

[CreateAssetMenu(fileName = "SpreadShot_SO", menuName = "Scriptable Objects/Weapon_SO/SpreadShot_SO")]

public class SpreadShot_SO : Weapon_SO
{
    [Tooltip("dont use higher number than 360")]
    [SerializeField] private float _spreadAngle = 30f;
    [SerializeField] int _numberOfShots = 5;

    public override void Attack(Projectile projectilePrefab, Unit sourceUnit, Transform attackDirection)
    {
        Debug.Log("shot from SpreadShot_SO");
        int angles = _numberOfShots - 1;
        float angleBetweenTwoProjectiles = _spreadAngle / (_numberOfShots - 1);
        float attackDirectionInDegree = attackDirection.rotation.eulerAngles.z;
                
        //Debug.Log(attackDirectionInDegree.ToString());
        float angleOfShot = attackDirectionInDegree - (_spreadAngle / 2);
        
        for (int i = 0; i < _numberOfShots; i++)
        {
            Quaternion directionOfProjectile = Quaternion.Euler(attackDirection.rotation.x, attackDirection.rotation.y, angleOfShot);

            Projectile projectile;
            projectile = Instantiate(projectilePrefab, sourceUnit.transform.position, directionOfProjectile);
            projectile.damage = sourceUnit.damage;
            projectile.targetTag = sourceUnit.targetTag;
            projectile.sourceUnit = sourceUnit;

            angleOfShot += angleBetweenTwoProjectiles;
        }
    }

}
