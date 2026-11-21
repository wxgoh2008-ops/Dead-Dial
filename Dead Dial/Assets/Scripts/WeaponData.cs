using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon" , menuName = "Dead Dial/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public Sprite icon;
    public int damage = 10;
    public float attackCooldown = 0.5f;
    public float range = 1f;
}