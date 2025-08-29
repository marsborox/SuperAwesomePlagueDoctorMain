using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    public float healthMax = 1;//might be private
    public float healthCurrent;//might be private
    private Unit _unit;
    private void Awake()
    {
        _unit = GetComponent<Unit>();
    }

    void Start()
    {
        SubscribeToEventsPlayer();// when enable is run here, awake seems not to be finished in Unit for some reason (initialisation Order)
        InitialiseHealth();
        ResetHealth();
    }
    void Update()
    {
        
    }
    private void OnEnable()
    {
        
        ResetHealth();
        
        if (_unit.unitEventHandler == null)
        {
            //Debug.Log(_unit.name + " doesnt see its eventHandler OnEnable");
        }
        else if(!(_unit.unitEventHandler == null))
        {
            //Debug.Log(_unit.name + " does see its eventHandler OnEnable");
            SubscribeToEvents();
        }
        
    }
    private void OnDisable()
    {
        _unit.unitEventHandler.OnHealthChange -= ChangeHealth;
        _unit.unitEventHandler.OnResetHealth -= ResetHealth;
    }
    private void SubscribeToEvents()
    {
        _unit.unitEventHandler.OnHealthChange += ChangeHealth;
        _unit.unitEventHandler.OnResetHealth += ResetHealth;
    }
    private void SubscribeToEventsPlayer()
    {
        if (_unit is Player)
        {
            if (_unit.unitEventHandler == null)
            {
                //Debug.Log(_unit.name + " doesnt see its eventHandler PlayerSpecific");
            }
            else /*if (!(_unit.unitEventHandler == null))*/
            {
                //Debug.Log(_unit.name + " does see its eventHandler PlayerSpecific");
                SubscribeToEvents();//should work
            }
        }
    }
    private void InitialiseHealth()
    {
        if (_unit is Enemy)
        {
            healthMax = ((Enemy)_unit).enemyTemplate.healthMax;
        }
        else if (_unit is Player)
        {
            healthMax = ((Player)_unit).unitStats.healthMax;
        }
    }
    private void ResetHealth()
    {

        healthCurrent = healthMax;    
    }
    private void ChangeHealth(float changeHealthValue)
    {
        //Debug.Log(_unit.name+" changingHelath");
        healthCurrent += changeHealthValue;
        if (healthCurrent <= 0)
        { 
            _unit.unitEventHandler.Die();
        }
    }
    private void GotHit(int i)
    {//vieme ze event je triggernuty pre co nefunguje u hraca 
        //just testing
        Debug.Log("unitHealth healthMax event triggered with dmg " + i);
    }
    
}
