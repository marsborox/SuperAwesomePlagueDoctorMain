using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    public int healthMax = 10;//might be private
    public int healthCurrent;//might be private
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
        _unit.unitEventHandler.OnHealthChange -= ChangeHealth;
        _unit.unitEventHandler.OnResetHealth -= ResetHealth;
    }
    private void ResetHealth()
    {
        /*if (((Enemy)_unit).enemyTemplate == null)
        {
            healthCurrent = healthMax;
        }
        else
        {
            healthCurrent = ((Enemy)_unit).enemyTemplate.healthMax;
        }*/
        healthCurrent = healthMax;
    }
    void ChangeHealth(int changeHealthValue)
    {
        //Debug.Log("changingHelath");
        healthCurrent += changeHealthValue;
        if (healthCurrent <= 0)
        { 
            _unit.unitEventHandler.Die();
        }
    }
}
