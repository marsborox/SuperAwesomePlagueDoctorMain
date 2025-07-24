using UnityEngine;

[CreateAssetMenu(fileName = "Enemy_SO", menuName = "Scriptable Objects/Enemy_SO")]
public class Enemy_SO : ScriptableObject
{
    public int damage = 10;
    public int rewardScore = 5;
    public float movementSpeed = 300;
    public EnemyBehavior_SO enemyBehavior_SO;


}
