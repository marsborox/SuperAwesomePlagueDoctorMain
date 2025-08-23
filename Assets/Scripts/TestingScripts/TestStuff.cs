using UnityEngine;
using UnityEngine.UI;

public class TestStuff : MonoBehaviour, I_InitiateButton
{
    [SerializeField] Button buttonOC_PostWaveUI;
    [SerializeField] PostWave_UI postWave_UI;
    [SerializeField] Main_UI main_UI;


    void Start()
    {
        ((I_InitiateButton)this).InitiateButton(buttonOC_PostWaveUI,OpenClose_PostWaveUI);
    }
    void OpenClose_PostWaveUI()
    {
        main_UI.OpenCloseUI(postWave_UI);
    }

}
