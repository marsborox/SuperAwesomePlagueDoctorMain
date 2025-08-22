using UnityEngine;
using System;

public class MyGlobalEventHandler : MonoBehaviour
{
    public event Action OnEndOfWave;

    public void EndWave()
    {
        OnEndOfWave?.Invoke();
    }
}
