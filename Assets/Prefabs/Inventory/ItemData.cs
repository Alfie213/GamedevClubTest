using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Inventory/ItemData")]
public class ItemData : ScriptableObject
{
    public string Name;
    public ItemType Type;
    public int Price;
    public int MaxAmount;
    public bool Stackable => MaxAmount > 1;
    public Sprite Sprite;

    public enum ItemType
    {
        IntelligenceBook,
        StrenghtBook,
        Ingredient,
        HealthPotion,
        ManaPotion,
        Boomerang,
        BowArrow,
        Cyborg,
        Hat,
        Kusarigama,
        Orrery,
        Sablya,
        Shuriken,
        Sword
    }
}