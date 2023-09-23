using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public abstract class ItemBase : MonoBehaviour, IUsable
{
    [SerializeField] private ItemData itemData;
    public ItemData ItemData => itemData;

    private bool takeable;

    public abstract void Use();

    public delegate void ItemHandler(ItemBase itemBase, out bool added);
    public static event ItemHandler OnTake;

    private void OnMouseDown()
    {
        if (takeable)
        {
            bool added;
            OnTake.Invoke(this, out added);
            if (added)
            {
                Destroy(gameObject);
                return;
            }
        }
    }


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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            takeable = false;
        }
    }

    public void SetItemData(ItemData data)
    {
        itemData = data;
    }
}
