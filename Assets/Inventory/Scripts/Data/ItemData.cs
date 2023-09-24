using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Inventory/ItemData")]
public class ItemData : ScriptableObject
{
    public bool Stackable => MaxAmount > 1;
    
    public string Name;
    public ItemType Type;
    public Sprite Sprite;
    public int MaxAmount;

    public enum ItemType
    {
        None,
        BanditPants,
        BulletproofCloak,
        BulletproofCloakElbow,
        BulletproofCloakWrist,
        MilitaryHelmet,
        SovietBag
    }
}