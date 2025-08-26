using UnityEngine;

public class Unit : MonoBehaviour
{
    public EventHandler_Unit unitEventHandler;
    public UnitHealth unitHealth;
    public UnitStats unitStats;
    public string targetTag;

    public bool isAttackReady = true;//might be moved elsewhere


    public void Awake()
    {

    }
    public virtual void OnColliderTrigger(Collider2D other)
    { }
    public virtual void Die()
    { }

}
