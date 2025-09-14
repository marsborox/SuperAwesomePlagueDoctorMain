
using System.Collections.Generic;

using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Collections;

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
    public void CloseButtons()
    {
        foreach (PostWaveButton_UI button in _buttons)
        {
            //button.gameObject.SetActive(false);
            button.button.onClick.RemoveAllListeners();
        }
    }

    public void OpenButtons()
    {
        List<int> usedStatIndexes = new List<int>();
        foreach (PostWaveButton_UI button in _buttons)
        {
            //button.gameObject.SetActive(true);
            var statlist = mainUI.player.unitStats.statList;
            int randomStatIndex = GetRandomStat(statlist, usedStatIndexes);
            UnitStats_Player.Stat usedStat = statlist[randomStatIndex];


            button.statName.text = usedStat.name;
            button.statValue.text = usedStat.amount.ToString() + " + " + usedStat.upgradeAmount;
            
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
    private int GetRandomStat(List<UnitStats.Stat> statList, List<int> usedStatIndexes)
    {//random stat but check if is repeating
        int returnIndex;
        //returnIndex = 2;
        returnIndex = Random.Range(0, statList.Count);
        bool isDuplicate = true;
        while (isDuplicate)
        {
            isDuplicate = false;
            returnIndex = Random.Range(0, statList.Count);

            for (int i = 0; i < usedStatIndexes.Count; i++)
            {
                if (returnIndex == usedStatIndexes[i])
                {
                    isDuplicate = true;
                }
            }
        }
        usedStatIndexes.Add(returnIndex);
        return returnIndex;
    }
    private void CheckIfInList()
    {
        
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
