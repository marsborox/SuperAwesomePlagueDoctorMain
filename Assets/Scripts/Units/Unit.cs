using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public EventHandler_Unit unitEventHandler;
    public UnitHealth unitHealth;
    public UnitStats unitStats;
    public UnitEffects unitEffects;
    public EnemySpawner enemySpawner;
    public string targetTag;

    public bool isAttackReady = true;//might be moved elsewhere

    public bool isSpecialEffect = false;// this si for stuff like is exploding, or some stuff that should happen just once boud to Behavior_SO
    public void Awake()
    {

    }
    public virtual void OnColliderTrigger(Collider2D other)
    { }
    public virtual void Die()
    { }
        public float ReturnHealthCurrent()
    {

        return unitHealth.healthCurrent;
    }
    public float ReturnHealthMax()
    { 
        return unitStats.healthMax_s.amount;
    }
    public float ReturnDamageAmount()
    { 
        return unitStats.damage_s.amount;
    }
    public float ReturnMovementSpeedAmount()
    { 
        return unitStats.movementSpeed_s.amount;
    }
    public float ReturnAttackSpeedAmount()
    {
        return unitStats.attackSpeed_s.amount;
    }
    public float ReturnAttackIntervalAmount()
    { 
        return unitStats.attackInterval;
    }
    public float ReturnAttackTimer()
    { 
        return unitStats.attackTimer;
    }
    public float ReturnScoreAmount()
    {
        return unitStats.score;
    }
    public void TakeDamage(float damageAmount)
    { 
        unitEventHandler.ChangeHealth(-damageAmount);
    }
    public void GetHeal(float healAmount)
    {
        unitEventHandler.ChangeHealth(healAmount);
    }
    public void Attack()
    {
        unitEventHandler.Attack();
    }
    public void AddScore(int score)
    { 
        unitStats.score += score;
    }

}
