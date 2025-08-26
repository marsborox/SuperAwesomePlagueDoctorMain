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
        usedEnemy.transform.position = Vector2.MoveTowards(usedEnemy.transform.position, target.transform.position, ((Enemy)usedEnemy).unitStats.movementSpeed * Time.deltaTime);
    }
}
