using UnityEngine;

//[CreateAssetMenu(menuName = "Scriptable Objects/EnemyBehavior_SO")]
public class EnemyBehavior_SO : ScriptableObject
{
    public virtual void EnemyBehavior(Player target, Enemy usedEnemy)
    { 
        
    }
    public virtual void EnemyBehavior(int inputNumber) 
    {
        //just for test / note
    }
    public void MoveToTarget(Player target, Enemy usedEnemy)
    {
        usedEnemy.transform.position = Vector2.MoveTowards(usedEnemy.transform.position, target.transform.position, usedEnemy.movementSpeed * Time.deltaTime);

    }
}
