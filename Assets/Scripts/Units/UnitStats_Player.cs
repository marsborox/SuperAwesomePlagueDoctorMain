using UnityEditor;

using UnityEngine;

public class UnitStats_Player : UnitStats
{
    [SerializeField] private Player _player;


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
    void ChangeScore(int changeHealthValue)
    {
        _player.unitStats.score += changeHealthValue;
        //Debug.Log("HeroGotHit");
    }

    private void ResetScore()
    {
        _player.unitStats.score = 0;
    }
}
