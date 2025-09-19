using UnityEngine;

public interface I_MeleeAttack
{
    public void Attack(Unit target, Unit usedEnemy)
    {
        //Debug.Log("melee attacking from interface");
        ((Enemy)usedEnemy).isAttackReady = false;
        target.TakeDamage(usedEnemy.ReturnDamageAmount());
        usedEnemy.Attack();
    }
}
