using UnityEngine.UI;
using UnityEngine.Events;
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
}
