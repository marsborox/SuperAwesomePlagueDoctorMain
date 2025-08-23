using UnityEngine;
using TMPro;
public class UI : MonoBehaviour, I_InitiateButton
{
    public Main_UI mainUI;

    public void OpenCloseUI(UI ui)
    {
        if (ui.gameObject.activeSelf)
        {
            ui.gameObject.SetActive(false);
        }
        else if (!ui.gameObject.activeSelf)
        {
            ui.gameObject.SetActive(true);
        }
    }
}
