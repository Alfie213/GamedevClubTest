using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Inventory/ItemData")]
public class ItemData : ScriptableObject
{
    public string Name;
    public ItemType Type;
    public Sprite Sprite;
    public bool Stackable;

    public enum ItemType
    {
        BanditPants,
        BulletproofCloak,
        BulletproofCloakElbow,
        BulletproofCloakWrist,
        MilitaryHelmet,
        SovietBag
    }
}