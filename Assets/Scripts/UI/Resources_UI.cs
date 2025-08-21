using TMPro;
using UnityEngine;

public class Resources_UI : UI
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    // Update is called once per frame
    void Update()
    {
        _scoreText.text = mainUI.player.score.ToString();
    }
}
