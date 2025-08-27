using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] MyGlobalEventHandler _myGlobalEventHandler;
    private void OnEnable()
    {
        _myGlobalEventHandler.OnPauseGame += PauseGame;
        _myGlobalEventHandler.OnResumeGame += SetTimeNormal;
    }
    private void OnDisable()
    {
        _myGlobalEventHandler.OnPauseGame -= PauseGame;
        _myGlobalEventHandler.OnResumeGame -= SetTimeNormal;
    }
    public void SetTimeNormal()
    {
        Time.timeScale = 1.0f;
    }
    public void PauseGame()
    { 
        Time.timeScale = 0f;
    }
}
