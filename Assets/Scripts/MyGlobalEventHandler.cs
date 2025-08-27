using UnityEngine;
using System;

public class MyGlobalEventHandler : MonoBehaviour
{
    public event Action OnEndOfWave;
    public Action OnPauseGame;
    public event Action OnResumeGame;
    public void EndWave()
    {
        OnEndOfWave?.Invoke();
        Pausegame();
    }
    public void Pausegame()
    { 
        OnPauseGame?.Invoke();
    }
    public void ResumeGame()
    { 
        OnResumeGame?.Invoke();
    }
}
