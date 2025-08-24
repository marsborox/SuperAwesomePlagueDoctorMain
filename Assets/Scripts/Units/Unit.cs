using UnityEngine;

public class Unit : MonoBehaviour
{
    public EventHandler_Unit unitEventHandler;
    public string targetTag;
    public int damage;
    public int healthMax=1;

    public float movementSpeed = 3;
    public float attackInterval=0;
    public float attackTimer = 0;

    public bool attackReady = true;


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
