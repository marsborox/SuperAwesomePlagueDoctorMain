using UnityEngine;


[CreateAssetMenu(fileName = "Enemy_SO", menuName = "Scriptable Objects/Enemy_SO")]
public class Enemy_SO : ScriptableObject
{
    public Color color;
    public EnemyBehavior_SO enemyBehavior_SO;

    public int damage = 10;
    public int rewardScore = 5;
    public int range = 3;
    public int healthMax = 2;
    public int attackSpeed = 50;
    public float movementSpeed = 300;
    //public float attackInterval = 2f;
    
    public void DoBehavior(Player target, Enemy usedEnemy)
    {
        if (enemyBehavior_SO == null)
        {
            DefaultBehavior(usedEnemy);
        }
        else
        {
            enemyBehavior_SO.EnemyBehavior(target,usedEnemy);
        }
    }
    private void DefaultBehavior(Enemy usedEnemy)
    {
        usedEnemy.transform.position = Vector2.MoveTowards(usedEnemy.transform.position, usedEnemy.target.transform.position, movementSpeed * Time.deltaTime);
    }
}