using UnityEngine;

public class Unit : MonoBehaviour
{
    public EventHandler_Unit unitEventHandler;
    public string targetTag;
    public int damage;
    public int healthMax=1;
    public UnitHealth unitHealth;
    public void Awake()
    {
        unitEventHandler = GetComponent<EventHandler_Unit>();
        unitHealth = GetComponent<UnitHealth>();
    }
    public virtual void OnColliderTrigger(Collider2D other)
    { }
    public virtual void Die()
    { }

}
