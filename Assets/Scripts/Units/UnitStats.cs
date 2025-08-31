using System;
using System.Collections.Generic;

using Unity.Hierarchy;

using UnityEngine;

public class UnitStats : MonoBehaviour
{
    public struct Stat { string name; float value; Action upgradeMethod; }
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
    public List<float> statListFloat = new List<float>();
    public List<Stat> statList = new List<Stat>();
    public void Start()
    {
        CountAttackInterval();
        AddStatsToList();
    }
    void SetStats()
    {
        
    }
    public void CountAttackInterval()
    {
        attackInterval = attackSpeed / SpeedToIntervaL;
        Debug.Log(nameof(attackSpeed) + " " + attackSpeed);
    }
    private void AddStatsToList()
    {
        if (statListFloat.Count == 0)
        {
            statListFloat.Add(healthMax);
            statListFloat.Add(damage);
            statListFloat.Add(movementSpeed);
            statListFloat.Add(attackSpeed);
        }
    }
    public float ReturnRandomStat()
    {
        /*
        float nbr = 1f;
        return nbr;*/

        int random = Random.Range(0, statListFloat.Count-1);
        return statListFloat[random];
    }
}
