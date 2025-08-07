using UnityEngine;

public class Attack_Player: MonoBehaviour
{
    [SerializeField] public Projectile projectile;
    [SerializeField] public int damage = 1;
    [SerializeField] private MouseFollow _mouseFollow;
    [SerializeField] private Weapon_SO _currentWeapon;
    [SerializeField] private Player _player;

    //[SerializeField] private string _targetTag = "Enemy";

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    public void Shoot()
    {
        Projectile projectile;
        projectile = Instantiate(this.projectile, transform.position, _mouseFollow.transform.rotation);
        projectile.damage = damage;
        projectile.targetTag = _player.targetTag;
        projectile.sourceUnit = _player;
    }
    public void Attack()
    {
        if (_currentWeapon == null)
        {
            Debug.Log("NoWeaponEquipped");
        }
        else
        {
            //add logic if ranged
            
            Debug.Log("WeaponEquipped");
            _currentWeapon.Attack(projectile,_player, _mouseFollow.transform);
            _currentWeapon.Attack(projectile, _player, _mouseFollow.transform, _mouseFollow.transform.rotation);
        }
    }
}
