using UnityEngine;
using System;
public class EventHandler_Unit : MonoBehaviour
{
    public delegate void HealthChangeEvent(float healthChangeValue);
    public event HealthChangeEvent OnHealthChange;
    public delegate void ScoreChangeEvent(float scoreToAdd);
    public event ScoreChangeEvent OnScoreChange;
    public event Action OnDeath;
    public event Action OnResetHealth;
    public event Action OnResetScore;
    public event Action OnAttack;
    public void ChangeHealth(float healthChangeValue)
    {
        OnHealthChange?.Invoke(healthChangeValue);
        Debug.Log("HealthChangeEvent run");
    }
    public void ChangeScore(float healthChangeValue)
    { 
        OnScoreChange?.Invoke(healthChangeValue);
    }
    public void Die() 
    {
        OnDeath?.Invoke();
    }
    public void ResetHealth()
    {
        OnResetHealth?.Invoke();
    }
    public void ResetScore()
    { 
        OnResetScore?.Invoke();
    }
    public void Attack()
    { 
        OnAttack?.Invoke();
    }

}
