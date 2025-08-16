using UnityEngine;

public class UnitVisualCollider : MonoBehaviour
{
    [SerializeField] private Unit unit;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("triggerred collider");
        unit.OnColliderTrigger(other);
        /*
        if (unit is Enemy)
        {
            ((Enemy)unit).OnColliderTrigger(other);
        }
        else if (unit is Player) 
        {
            ((Player)unit).OnColliderTrigger(other);
        }*/
    }
}
