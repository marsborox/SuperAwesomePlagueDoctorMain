using UnityEngine;

[CreateAssetMenu(fileName = "Weapon_SO"/*, menuName = "Scriptable Objects/Weapon_SO"*/)]
public class Weapon_SO : ScriptableObject
{

    public virtual void Attack()
    { 
    
    }
    public virtual void Attack(Projectile projectilePrefab, Unit sourceUnit, Transform shootDirection)
    { 
    
    }


}
