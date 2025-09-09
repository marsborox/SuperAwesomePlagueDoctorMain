using UnityEngine;

//[CreateAssetMenu(menuName = "Scriptable Objects/EnemyBehavior_SO")]
public class EnemyBehavior_SO : ScriptableObject
{
    public virtual void EnemyBehavior(Unit target, Unit usedEnemy)
    { 
        
    }
    public virtual void EnemyBehavior(int inputNumber) 
    {
        //just for test / note
    }
    public void MoveToTarget(Unit target, Unit usedEnemy)
    {
        usedEnemy.transform.position = Vector2.MoveTowards(usedEnemy.transform.position, target.transform.position, ((Enemy)usedEnemy).unitStats.movementSpeed_s.amount * Time.deltaTime);
    }

    public bool IsInRange(Unit target, Unit usedEnemy)
    {
        float distance = Vector2.Distance(target.transform.position, usedEnemy.transform.position);
        if (distance < ((Enemy)usedEnemy).range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Attack(Unit target, Unit usedEnemy)
    {

    }
    public void TouchedTarget(Unit usedEnemy)
    { 
        
    }
}
