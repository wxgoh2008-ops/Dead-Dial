using UnityEngine;

[CreateAssetMenu(fileName = "NewArmour" , menuName = "Dead Dial/Armour")]
public class ArmourData : ScriptableObject
{
    public string armourName;
    public Sprite icon;
    public int defence = 2;
}