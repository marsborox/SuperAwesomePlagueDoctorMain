using NUnit.Framework;

using UnityEngine;

public class UnitStats : MonoBehaviour
{
    //public UnitStats unitStats;
    [Tooltip("Health")]
    public float healthMax = 1;
    [Tooltip("Damage")]
    public float damage = 1;
    public float movementSpeed = 3;
    [Tooltip("Attack_Damage")]
    public float attackSpeed = 100; //
    public float attackInterval;
    public float attackTimer = 0;
    [SerializeField] private float SpeedToIntervaL = 100;

    public float score = 0;
    
    public void Start()
    {
        CountAttackInterval();
    }

    public void CountAttackInterval()
    {
        attackInterval = attackSpeed / SpeedToIntervaL;
    Debug.Log(nameof(attackSpeed) + " " + attackSpeed);
    }
    
}
