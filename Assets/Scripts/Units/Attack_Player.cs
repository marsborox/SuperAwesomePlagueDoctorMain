using UnityEngine;

public class Attack_Player: MonoBehaviour
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private MouseFollow _mouseFollow;
    [SerializeField] private Weapon_SO _currentWeapon;
    [SerializeField] private Player _player;
    [SerializeField] private int _damage = 1;

    [SerializeField] private string _targetTag = "Enemy";

    private void Awake()
    {
        _player = GetComponent<Player>();
        
    }
    public void Shoot()
    {
        Projectile projectile;
        projectile = Instantiate(_projectile, transform.position, _mouseFollow.transform.rotation);
        projectile.damage = _damage;
        projectile.targetTag = _targetTag;
        projectile.sourceUnit = _player;
    }
    public void Attack()
    { 
        _currentWeapon.Attack();
    }
}
