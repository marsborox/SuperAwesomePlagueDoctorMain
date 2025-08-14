using UnityEngine;

public class Attack_Player: MonoBehaviour
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] public int damage = 1;
    [SerializeField] private MouseFollow _mouseFollow;
    [SerializeField] private Action_SO _activeAction;
    [SerializeField] private Player _player;

    //[SerializeField] private string _targetTag = "Enemy";

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    public void Shoot()
    {//not used
        Projectile projectile;
        projectile = Instantiate(this._projectile, transform.position, _mouseFollow.transform.rotation);
        projectile.damage = damage;
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
            //add logic if ranged
            
            Debug.Log("WeaponEquipped");
            //_currentWeapon.Attack(projectile,_player, _mouseFollow.transform);
            _activeAction.Attack(/*projectile,*/ _player, _mouseFollow.transform, _mouseFollow.transform.rotation);
        }
    }
}
