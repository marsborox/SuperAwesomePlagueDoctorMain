using UnityEngine;

public class Main_UI : UI
{
    public Player player;

    [SerializeField] PostWave_UI postWave_UI;

    void OpenClose_PostWaveUI()
    {
        OpenCloseUI(postWave_UI);
    }
}
