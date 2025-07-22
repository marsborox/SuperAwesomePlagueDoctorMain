using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private MouseFollow _mouseFollow;

    [SerializeField] private Weapon_SO _currentWeapon;
    public void Shoot()
    {
        Instantiate(_bullet.gameObject, transform.position, _mouseFollow.transform.rotation);
    }
    public void Attack()
    { 
        _currentWeapon.Attack();
    }
}
