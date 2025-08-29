using System;
using System.Collections.Generic;

using NUnit.Framework;

using UnityEngine;
using UnityEngine.UI;

public class PostWave_UI : UI , I_InitiateButton
{

    [SerializeField] Button _resumeButton;
    [SerializeField] private PostWaveButton_UI _option1;
    [SerializeField] private PostWaveButton_UI _option2;
    [SerializeField] private PostWaveButton_UI _option3;

    [SerializeField]List <PostWaveButton_UI> _buttons = new List<PostWaveButton_UI>();
    void OpenButtons(float stat)
    {
        foreach (PostWaveButton_UI button in _buttons)
        {
            button.gameObject.SetActive(true);

            //((I_InitiateButton)this).InitiateButton(button,)
            button.statName.text = nameof(stat);
            button.statValue.text = stat.ToString();
        }
    }
    void OpenButtons(int stat)
    {
        foreach (PostWaveButton_UI button in _buttons)
        {
            button.gameObject.SetActive(true);
            button.statName.text = nameof(stat);
            button.statValue.text = stat.ToString();

        }
    }
    void OpenButtons()
    {
        foreach (PostWaveButton_UI button in _buttons)
        {
            button.gameObject.SetActive(true);
            var stat = 5;//only for dev remove later
            //mainUI.player.unitStats.    //some method to give me random stat;
            //((I_InitiateButton)this).InitiateButton(button, here that method)
            button.statName.text = nameof(stat);
            button.statValue.text = stat.ToString();
        }
    }
    void SetButtonProperties(PostWaveButton_UI button)
    {

        string strin = "string";
        button.statName.text = strin;
        button.statValue.text = strin;
    }

}
