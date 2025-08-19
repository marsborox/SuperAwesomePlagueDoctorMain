using UnityEngine;
using System;
public class EventHandler_Unit : MonoBehaviour
{
    public delegate void HealthChangeEvent(int healthChangeValue);
    public event HealthChangeEvent OnHealthChange;
    public delegate void ScoreChangeEvent(int scoreToAdd);
    public event ScoreChangeEvent OnScoreChange;
    public event Action OnDeath;
    public event Action OnResetHealth;
    public event Action OnResetScore;
    public void ChangeHealth(int healthChangeValue)
    {
        OnHealthChange?.Invoke(healthChangeValue);
        //Debug.Log("HealthChangeEvent run");
    }
    public void ChangeScore(int healthChangeValue)
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

}
