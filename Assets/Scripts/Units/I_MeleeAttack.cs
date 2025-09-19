using UnityEngine;
using System;
public interface I_MeleeAttack
{
    void Attack()
    {
        Debug.Log("testing attack in interface");
    }
    public void Attack(Unit target, Unit usedEnemy)
    {
        Debug.Log("melee attacking from interface");
        /*((Enemy)usedEnemy)*/usedEnemy.isAttackReady = false;
        target.TakeDamage(usedEnemy.ReturnDamageAmount());
        usedEnemy.Attack();
    }
}
