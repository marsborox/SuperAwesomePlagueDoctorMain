using UnityEngine.UI;
using System;
public interface I_InitiateButton
{
    public void InitiateButton(Button button, Action method)
    {
        button.onClick.AddListener(delegate
        {
            method();
            //SoundManager.instance.Click();
        });
        //boolUI = false;
    }
    public void InitiateButton<T>(Button button, Action<T> method, T value)
    {
        button.onClick.AddListener(delegate
        {
            method(value);
            //SoundManager.instance.Click();
        });
        //boolUI = false;
    }

}
