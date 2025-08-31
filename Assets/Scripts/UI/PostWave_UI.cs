
using System.Collections.Generic;

using NUnit.Framework;

using UnityEditor.Rendering;

using UnityEngine;
using UnityEngine.UI;

public class PostWave_UI : UI , I_InitiateButton
{

    [SerializeField] Button _resumeButton;
    [SerializeField] private PostWaveButton_UI _option1;
    [SerializeField] private PostWaveButton_UI _option2;
    [SerializeField] private PostWaveButton_UI _option3;

    [SerializeField]List <PostWaveButton_UI> _buttons = new List<PostWaveButton_UI>();

    void Start()
    { 
    
    }
    void OnEnable()
    {
        OpenButtons();
    }
    void OnDisable()
    {
        foreach (PostWaveButton_UI button in _buttons)
        {
            button.gameObject.SetActive(false);
        }
    }
    /*private void OpenButtons(float stat)
    {
        foreach (PostWaveButton_UI button in _buttons)
        {
            button.gameObject.SetActive(true);

            //((I_InitiateButton)this).InitiateButton(button,)
            button.statName.text = nameof(stat);
            button.statValue.text = stat.ToString();
        }
    }*/


    /*void OpenButtons(int stat)
    {
        foreach (PostWaveButton_UI button in _buttons)
        {
            button.gameObject.SetActive(true);
            button.statName.text = nameof(stat);
            button.statValue.text = stat.ToString();

        }
    }*/
    private void OpenButtons()
    {
        foreach (PostWaveButton_UI button in _buttons)
        {
            button.gameObject.SetActive(true);
            var stat = 5f;//only for dev remove later
            //mainUI.player.unitStats.    //some method to give me random stat;
            //((I_InitiateButton)this).InitiateButton(button, here that method)
            //var stat = nameOf (mainUI.player.unitStats.ReturnRandomStat());
            /*var statlist = mainUI.player.unitStats.statListFloat;
            int randomStatIndex = Random.Range(0, statlist.Count-1);


            button.statName.text = nameof(statlist[randomStatIndex]);
            button.statValue.text = statlist[randomStatIndex].ToString();
            var unitStats = mainUI.player.unitStats;
            
            ((I_InitiateButton)this).InitiateButton((UnitStats_Player)unitStats).UpgradeStat(statlist[randomStatIndex], (UnitStats_Player)unitStats.upgradeAmount);*/
        }
    }
    void SetButtonProperties(PostWaveButton_UI button)
    {

        string strin = "string";
        button.statName.text = strin;
        button.statValue.text = strin;
    }

    private float ReturnValueSetText(PostWaveButton_UI button)
    {
        float nbr = 5f;
        //int random = Random.Range(0,mainUi.)//
        return nbr;
    }

}
