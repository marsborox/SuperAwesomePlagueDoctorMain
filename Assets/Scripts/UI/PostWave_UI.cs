using UnityEngine;
using UnityEngine.UI;

public class PostWave_UI : UI , I_InitiateButton
{

    [SerializeField] Button _resumeButton;
    [SerializeField] private Main_UI _mainUi;
    [SerializeField] private PostWaveButton_UI _option1;
    [SerializeField] private PostWaveButton_UI _option2;
    [SerializeField] private PostWaveButton_UI _option3;

    void SetButtonProperties(PostWaveButton_UI button)
    {
        string strin = "string";
        button.statName.text = strin;
        button.statValue.text = strin;
    }
}
