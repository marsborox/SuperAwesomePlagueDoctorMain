using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    public int healthMax = 10;//might be private
    public int health;//might be private
    private Unit _unit;
    private void Awake()
    {
        _unit = GetComponent<Unit>();        
    }
    void Start()
    {
        ResetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        _unit.unitEventHandler.OnHealthChange += ChangeHealth;
        _unit.unitEventHandler.OnResetHealth += ResetHealth;
    }
    private void OnDisable()
    {
        _unit.unitEventHandler.OnHealthChange += ChangeHealth;
    }
    private void ResetHealth()
    {
        health = healthMax;
    }
    void ChangeHealth(int changeHealthValue)
    {
        health += changeHealthValue;
        if (health < 0)
        { 
            _unit.unitEventHandler.Die();
        }
    }
}
