using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] availableItems;
    [SerializeField] private Transform spawnParent;
    
    private void OnEnable()
    {
        EventBus.EnemyDeath.Subscribe(Handle_EnemyDeath);
    }

    private void OnDisable()
    {
        EventBus.EnemyDeath.Unsubscribe(Handle_EnemyDeath);
    }

    private void Handle_EnemyDeath(Vector3 position)
    {
        SpawnRandomItem(position);
    }

    private void SpawnRandomItem(Vector3 position)
    {
        Instantiate(availableItems[Random.Range(0, availableItems.Length)], position, Quaternion.identity, spawnParent);
    }
}
