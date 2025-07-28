using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private MouseFollow _mouseFollow;
    [SerializeField] private Weapon_SO _currentWeapon;
    [SerializeField] private Player _player;


    private void Awake()
    {
        _player = GetComponent<Player>();
        
    }
    public void Shoot()
    {
        Projectile bullet;
        bullet = Instantiate(_projectile, transform.position, _mouseFollow.transform.rotation);
        
    }
    public void Attack()
    { 
        _currentWeapon.Attack();
    }
}
