using UnityEngine;

public interface I_MeleeAttack
{
    public void MeleeAttack()
    {
        Debug.Log("melee interface working");
    }
    public void MeleeAttack(Unit target, Unit usedEnemy)
    {
        //Debug.Log("melee attacking from interface");
        ((Enemy)usedEnemy).isAttackReady = false;
        target.TakeDamage(usedEnemy.ReturnDamageAmount());
        usedEnemy.Attack();
    }
}
