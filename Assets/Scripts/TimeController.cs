using UnityEngine;

public class TimeController : MonoBehaviour
{
    public void SetTimeNormal()
    {
        Time.timeScale = 1.0f;
    }
    public void PauseGame()
    { 
        Time.timeScale = 0f;
    }
}
