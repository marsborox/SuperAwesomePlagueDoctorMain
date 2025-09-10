using UnityEngine;

[CreateAssetMenu(fileName = "BomberBehavior_SO", menuName = "Scriptable Objects/EnemyBehavior_SO/BomberBehavior_SO")]
public class BomberBehavior_SO : EnemyBehavior_SO
{
    [SerializeField] Explosion explosion;

    public override void EnemyBehavior(Unit target, Unit usedEnemy)
    {
        MoveToTarget(target, usedEnemy);
    }
    public override void TouchedTarget(Unit usedEnemy)
    {
        Debug.Log("Should be exploding rn");
        Explosion explodingExplosion = Instantiate(explosion);

        explodingExplosion.damage = usedEnemy.ReturnDamageAmount();
        explodingExplosion.targetTag = usedEnemy.targetTag;
        explodingExplosion.sourceUnit = usedEnemy;
        explodingExplosion.movementSpeed = 0f;
        explodingExplosion.transform.position = usedEnemy.transform.position;
        usedEnemy.gameObject.SetActive(false);

    }
}
