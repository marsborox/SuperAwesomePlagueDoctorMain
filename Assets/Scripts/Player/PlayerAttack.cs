using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private MouseFollow _mouseFollow;

    public void Shoot()
    {
        Instantiate(_bullet.gameObject, transform.position, _mouseFollow.transform.rotation);
    }
}
