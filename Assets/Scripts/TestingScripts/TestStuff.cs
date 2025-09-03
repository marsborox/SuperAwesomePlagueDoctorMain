using UnityEngine;
using UnityEngine.UI;

public class TestStuff : MonoBehaviour, I_InitiateButton
{
    [SerializeField] private MyGlobalEventHandler _myGlobalEventHandler;
    [SerializeField] private PostWave_UI _postWave_UI;
    [SerializeField] private Main_UI _main_UI;
    [SerializeField] private Button _buttonOC_PostWaveUI;
    [SerializeField] private Button _resumeGameBTN;

    void Start()
    {
        ((I_InitiateButton)this).InitiateButton(_buttonOC_PostWaveUI,OpenClose_PostWaveUI);
        ((I_InitiateButton)this).InitiateButton(_resumeGameBTN, _myGlobalEventHandler.ResumeGame);
    }
    void OpenClose_PostWaveUI()
    {
        _main_UI.OpenCloseUI(_postWave_UI);
    }
}
