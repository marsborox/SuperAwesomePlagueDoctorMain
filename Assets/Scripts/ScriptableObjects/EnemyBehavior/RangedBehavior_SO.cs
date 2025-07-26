using UnityEngine;

[CreateAssetMenu(fileName = "RangedBehavior_SO", menuName = "Scriptable Objects/EnemyBehavior_SO/RangedBehavior_SO")]
public class RangedBehavior_SO : EnemyBehavior_SO
{
    public override void EnemyBehavior(Player target, Enemy UsedEnem)
    {
        Debug.Log("Enemy is Behaving Ranged");
    }

}
