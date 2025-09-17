using UnityEngine;

[CreateAssetMenu(fileName = "Weapon_SO", menuName = "Scriptable Objects/Weapon_SO")]
public class Weapon_SO : ScriptableObject
{
    public Action_SO attackAction;
    public Sprite weaponSprite;
}
