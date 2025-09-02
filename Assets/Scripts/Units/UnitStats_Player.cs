using UnityEditor;
using UnityEditor.Rendering.Universal;

using UnityEngine;

public class UnitStats_Player : UnitStats
{
    public int upgradeAmount;
    [SerializeField] private Player _player;


    private void Start()
    {
        base.Start();
    }
    public void OnEnable()
    {
        _player.unitEventHandler.OnScoreChange += ChangeScore;
        _player.unitEventHandler.OnResetScore += ResetScore;
    }
    private void OnDisable()
    {
        _player.unitEventHandler.OnScoreChange -= ChangeScore;
        _player.unitEventHandler.OnResetScore -= ResetScore;
    }


    public void UpgradeMaxHealth()
    {
        UpgradeStatAny(ref healthMax_s);
        UpgradeStat(_player.unitHealth.healthCurrent, healthMax_s.upgradeAmount);
    }
    public void UpgradeDamage()
    {
        UpgradeStatAny(ref damage_s);
    }
    public void UpgradeMovementSpeed()
    {
        UpgradeStatAny(ref movementSpeed_s);
    }
    public void UpgradeAttackSpeed()
    {
        UpgradeStatAny(ref attackSpeed_s);
        CountAttackInterval();
    }

    private void ChangeScore(float changeHealthValue)
    {
        _player.unitStats.score += changeHealthValue;
        //Debug.Log("HeroGotHit");
    }

    private void ResetScore()
    {
        _player.unitStats.score = 0;
    }


    private void UpgradeStat(float stat, float increase)
    {
        stat += increase;
    }

    public void UpgradeStatAny(ref Stat stat)
    {
        stat.amount += stat.upgradeAmount;
        Debug.Log("Upgrading stat " + stat.name + " to value " + stat.amount.ToString());
    }
    public void UpgradeStat(string statText)
    {
        switch (statText)
        {
            case "healthMax":
                UpgradeMaxHealth();
                break;
            case "damage":
                UpgradeDamage();
                break;
            case "attackSpeed":
                UpgradeAttackSpeed();
                break;
            case "movementSpeed":
                UpgradeMovementSpeed();
                break;
            default:
                Debug.LogError("UnitStat_Player. issueWithStat");
                break;
        }
    }
}
