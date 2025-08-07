using UnityEngine;


public class Weapon_SO : ScriptableObject
{

    public virtual void Attack()
    { 
    
    }
    public virtual void Attack(Projectile projectilePrefab, Unit sourceUnit, Transform shootRotation)
    { 
    
    }
    public virtual void Attack(Projectile projectilePrefab, Unit sourceUnit, Transform shootRotation, Quaternion shootDirection)
    {

    }

}
