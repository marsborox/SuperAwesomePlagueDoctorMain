using UnityEngine;

[CreateAssetMenu(fileName = "BomberBehavior_SO", menuName = "Scriptable Objects/EnemyBehavior_SO/BomberBehavior_SO")]
public class BomberBehavior_SO : EnemyBehavior_SO
{
    [SerializeField] Explosion explosion;

    public void TouchedTarget(Unit sourceUnit)
    {
        Debug.Log("Should be exploding rn");
        Explosion explodingExplosion = Instantiate(explosion);

        explodingExplosion.damage = sourceUnit.ReturnDamageAmount();
        explodingExplosion.targetTag = sourceUnit.targetTag;
        explodingExplosion.sourceUnit = sourceUnit;
        explodingExplosion.movementSpeed = 0f;
        Destroy(sourceUnit.gameObject);
    }
}
