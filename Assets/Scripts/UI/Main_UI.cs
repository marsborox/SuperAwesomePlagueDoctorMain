using UnityEngine;

public class Main_UI : UI
{
    public Player player;

    [SerializeField] private PostWave_UI _postWave_UI;
    [SerializeField] private MyGlobalEventHandler _myGlobalEventHandler;

    private void OnEnable()
    {
        _myGlobalEventHandler.OnEndOfWave += OpenClose_PostWaveUI;
    }
    private void OnDisable()
    {
        _myGlobalEventHandler.OnEndOfWave -= OpenClose_PostWaveUI;
    }
    void OpenClose_PostWaveUI()
    {
        OpenCloseUI(_postWave_UI);
    }
    


}
