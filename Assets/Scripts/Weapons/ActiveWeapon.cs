using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    public Weapon_SO tempInputWeapon;//till changing weapons is resolved
    public Weapon_SO activeWeaponSO;
    [SerializeField] private MouseFollow _mouseFollow;
    [SerializeField] private SpriteRenderer _weaponSprite;
    [SerializeField] private Player _player;


    private void Start()
    {
        ChangeWeapon(tempInputWeapon);
    }
    void Update()
    {
        WeaponRotation();
        FlipSprite();
    }
    void WeaponRotation()
    {//this does not know right and weapon is facing left
        this.transform.right = -_mouseFollow.transform.up;

    }
    void ChangeWeapon(Weapon_SO inputWeapon)
    { 
        activeWeaponSO = inputWeapon;
        _weaponSprite.sprite = inputWeapon.weaponSprite;
    }
    public void Attack()
    { 
        activeWeaponSO.attackAction.Attack(_player, _mouseFollow.transform, _mouseFollow.transform.rotation);
    }
    void FlipSprite()
    {
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        
        //Quaternion rotation = _mouseFollow.transform.localEulerAngles.z;
        float angle = _mouseFollow.transform.localEulerAngles.z-90;
        Debug.Log(angle);
        if (Input.mousePosition.x > playerScreenPoint.x)
        {
            //Debug.Log("right");
            transform.rotation = Quaternion.Euler(180f, 0f, -angle);
        }
        else if (Input.mousePosition.x < playerScreenPoint.x)
        {
            //Debug.Log("left");
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
