using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class UnitAttackIndicator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _IndicatorSprite;
    [SerializeField] private Image _cooldownImage;

    [SerializeField] private Unit _unit;



    private void Update()
    {
        DoCooldownVisuals();
    }


    private void Start()
    {
        
    }
    private void OnEnable()
    {
        _unit.unitEventHandler.OnAttack += AttackAnimationRoutineMethod;
    }
    private void OnDisable()
    {
        _unit.unitEventHandler.OnAttack -= AttackAnimationRoutineMethod;
    }

    private void AttackAnimationRoutineMethod()
    {
        StartCoroutine(AttackAnimationRoutine());
    }
    IEnumerator AttackAnimationRoutine()
    { 
        _IndicatorSprite.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _IndicatorSprite.gameObject.SetActive(false);
    }
    private void DoCooldownVisuals()
    {
        if (_unit.isAttackReady)
        { 
            _cooldownImage.gameObject.SetActive(false);
        }
        else
        {
            _cooldownImage.gameObject.SetActive(true);
            _cooldownImage.fillAmount = (_unit.ReturnAttackTimer() / _unit.ReturnAttackIntervalAmount());
        }
    }
}
