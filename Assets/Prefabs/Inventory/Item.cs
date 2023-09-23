using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class Item : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    public ItemData ItemData => itemData;

    public delegate void ItemHandler(Item item, out bool added);
    public static event ItemHandler OnTake;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool added;
        if (collision.gameObject.CompareTag("Player"))
        {
            OnTake.Invoke(this, out added);
            if (added)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetItemData(ItemData data)
    {
        itemData = data;
    }
}
