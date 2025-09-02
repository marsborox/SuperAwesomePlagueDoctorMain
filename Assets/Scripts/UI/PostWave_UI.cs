
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostWave_UI : UI , I_InitiateButton
{
    [SerializeField] private List <PostWaveButton_UI> _buttons = new List<PostWaveButton_UI>();
    [SerializeField] private MyGlobalEventHandler _eventHandler;

    void Start()
    { 
    
    }
    void OnEnable()
    {
        OpenButtons();
    }
    void OnDisable()
    {
        CloseButtons();
    }

    public void OpenButtons()
    {
        foreach (PostWaveButton_UI button in _buttons)
        {
            //button.gameObject.SetActive(true);
            
            var statlist = mainUI.player.unitStats.statList;
            int randomStatIndex = Random.Range(0, statlist.Count);
              
            button.statName.text = statlist[randomStatIndex].name;
            button.statValue.text = statlist[randomStatIndex].amount.ToString() + " + " + statlist[randomStatIndex].upgradeAmount;
            
            var unitStats = mainUI.player.unitStats;
            void SimplifyButtonMethod()
            {
                ((UnitStats_Player)unitStats).UpgradeStat(button.statName.text);
                _eventHandler.ResumeGame();
                mainUI.OpenCloseUI(this);
            }
            ((I_InitiateButton)this).InitiateButton(button.button, SimplifyButtonMethod);
        }
    }
    public void CloseButtons()
    {
        foreach (PostWaveButton_UI button in _buttons)
        {
            //button.gameObject.SetActive(false);
            button.button.onClick.RemoveAllListeners();
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
