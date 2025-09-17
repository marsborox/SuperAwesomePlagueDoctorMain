using UnityEngine;

public class Attack_Player: MonoBehaviour
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private MouseFollow _mouseFollow;
    [SerializeField] private Action_SO _activeAction;
    [SerializeField] private Player _player;
    [SerializeField] private ActiveWeapon _activeWeapon;

    public bool isAttacking = false;
    

    private void Awake()
    {
        _player = GetComponent<Player>();
    }
    private void FixedUpdate()
    {
        ContinuousAttacking();
        RefreshTimer();
    }

    public void Shoot()
    {//not used
        Projectile projectile;
        projectile = Instantiate(this._projectile, transform.position, _mouseFollow.transform.rotation);
        projectile.damage = _player.ReturnDamageAmount();
        projectile.targetTag = _player.targetTag;
        projectile.sourceUnit = _player;
        Debug.Log("PlayerShoot");
    }
    public void Attack()
    {
        
        if (_activeAction == null)
        {
            Debug.Log("NoWeaponEquipped");
        }
        else
        {
            //_activeAction.Attack(/*projectile,*/ _player, _mouseFollow.transform, _mouseFollow.transform.rotation);
            _activeWeapon.Attack();
            _player.isAttackReady = false;
        }

    }
    private void ContinuousAttacking()
    {
        if (isAttacking && _player.isAttackReady)
        {
            //_activeAction.Attack(/*projectile,*/ _player, _mouseFollow.transform, _mouseFollow.transform.rotation);
            _activeWeapon.Attack();
            _player.isAttackReady = false;
        }
    }
    private void RefreshTimer()
    {
        var playerStats = _player.unitStats;
        if (!_player.isAttackReady)
        {
            playerStats.attackTimer += Time.deltaTime;
        }
        if (playerStats.attackTimer >= playerStats.attackInterval)
        {
            playerStats.attackTimer = playerStats.attackTimer - playerStats.attackInterval;
            _player.isAttackReady = true;
        }
    }

}
