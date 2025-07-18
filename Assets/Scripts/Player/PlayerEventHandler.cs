using UnityEngine;

public class PlayerEventHandler : MonoBehaviour
{
    public delegate void HealthChangeEvent(int healthChangeValue);
    public event HealthChangeEvent OnHealthChange;

    public void ChangeHealth(int healthChangeValue)
    {
        OnHealthChange?.Invoke(healthChangeValue);
    }
}
