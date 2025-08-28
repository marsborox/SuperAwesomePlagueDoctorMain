using UnityEngine;

public class UnitStats : MonoBehaviour
{
    //public UnitStats unitStats;
    public int damage = 1;
    public int healthMax = 1;
    public int attackSpeed = 100; //
    public float movementSpeed = 3;
    public float attackInterval;
    public float attackTimer = 0;
    [SerializeField] private int SpeedToIntervaL = 100;

    public int score = 0;

    public void Start()
    {
        CountAttackInterval();
    }

    public void CountAttackInterval()
    {
        attackInterval = (float)attackSpeed / (float)SpeedToIntervaL;
    }
}
