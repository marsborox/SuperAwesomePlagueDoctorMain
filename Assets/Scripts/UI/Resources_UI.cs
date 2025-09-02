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
        _healthText.text = playerHealth.healthCurrent + " / " + mainUI.player.unitStats.healthMax_s.amount;
        _healthBarImage.fillAmount= ((float)playerHealth.healthCurrent/ mainUI.player.unitStats.healthMax_s.amount);
    }
    private void UpdateStats()
    {
        
        var playerStats = mainUI.player.unitStats;
        _scoreText.text = "Score: " + playerStats.score.ToString();
        _damageText.text = "Damage: " + playerStats.damage_s.amount.ToString();
        _attackIntervalText.text = "Atk Interval: " + playerStats.attackInterval.ToString();

    }
}
