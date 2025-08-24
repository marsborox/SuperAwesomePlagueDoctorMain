using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Resources_UI : UI
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private TextMeshProUGUI _attackIntervalText;

    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Image _healthBarImage;
    
    void Update()
    {

        UpdateHealth();
        UpdateStats();
    }

    private void UpdateHealth()
    {
        var playerHealth = mainUI.player.unitHealth;
        _healthText.text = playerHealth.healthCurrent + " / " + playerHealth.healthMax;
        _healthBarImage.fillAmount= ((float)playerHealth.healthCurrent/ (float)playerHealth.healthMax);
    }
    private void UpdateStats()
    {
        
        var player = mainUI.player;
        _scoreText.text = "Score: " + player.score.ToString();
        _damageText.text = "Damage: " + player.damage.ToString();
        _attackIntervalText.text = "Atk Interval: " + player.attackInterval.ToString();

    }
}
