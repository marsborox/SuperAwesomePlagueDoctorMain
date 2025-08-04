using UnityEngine;

public class Unit : MonoBehaviour
{
    public EventHandler_Unit unitEventHandler;
    public string targetTag;
    public int damage;
    public void Awake()
    {
        unitEventHandler = GetComponent<EventHandler_Unit>();
    }
}
