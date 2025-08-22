using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Resources_UI : UI
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    // Update is called once per frame
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Image _healthBarImage;
    void Update()
    {
        _scoreText.text = mainUI.player.score.ToString();
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        var playerHealth = mainUI.player.unitHealth;
        _healthText.text = playerHealth.healthCurrent + " / " + playerHealth.healthMax;
        _healthBarImage.fillAmount= ((float)playerHealth.healthCurrent/ (float)playerHealth.healthMax);
    }
}
