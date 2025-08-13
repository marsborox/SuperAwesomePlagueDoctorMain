using UnityEngine;
using System;
public class EventHandler_Unit : MonoBehaviour
{
    public delegate void HealthChangeEvent(int healthChangeValue);
    public event HealthChangeEvent OnHealthChange;
    public event Action OnDeath;
    public event Action OnResetHealth;
    public void ChangeHealth(int healthChangeValue)
    {
        OnHealthChange?.Invoke(healthChangeValue);
    }
    public void Die() 
    {
        OnDeath?.Invoke();
    }
    public void ResetHealth()
    {
        OnResetHealth?.Invoke();
    }
}
