using UnityEditor;

using UnityEngine;

public class UnitStats_Player : UnitStats
{
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

    public void UpgradeDamage(int increase)
    {
        UpgradeStat(damage, increase);
    }
    public void UpgradeAttackSpeed(int increase)
    {
        UpgradeStat(attackSpeed, increase);
        CountAttackInterval();
    }
    public void UpgradeMaxHealth(int increase)
    {
        UpgradeStat(healthMax,increase);
        UpgradeStat(_player.unitHealth.healthCurrent, increase);
    }

    private void ChangeScore(int changeHealthValue)
    {
        _player.unitStats.score += changeHealthValue;
        //Debug.Log("HeroGotHit");
    }

    private void ResetScore()
    {
        _player.unitStats.score = 0;
    }

    private void UpgradeStat(int stat, int increase)
    {
        stat += increase;
    }
}
