using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarImage;
    [SerializeField] private Unit _unit;

    void Start()
    {
        
    }

    void Update()
    {
        SetBarSize();
    }

    private void OnDisable()
    {
        
    }
    public void SetBarSize()
    {
        float fillAmount = (float)_unit.unitHealth.healthCurrent / _unit.unitStats.healthMax_s.amount;
        _healthBarImage.fillAmount = fillAmount;
    }
}
