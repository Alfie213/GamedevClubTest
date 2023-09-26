using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MonsterSpawner : MonoBehaviour
{
    [Header("Enemy settings")]
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int enemyHp;
    
    [Header("SpawnArea cornerPoints")]
    [SerializeField] private Transform cornerPoint1;
    [SerializeField] private Transform cornerPoint2;

    [Header("Hp bar")]
    [SerializeField] private GameObject hpBarSliderPrefab;
    [SerializeField] private float hpBarOffsetY;

    [Header("SpawnParents")]
    [SerializeField] private Transform hpBarSpawnParent;
    [SerializeField] private Transform monsterSpawnParent;
    
    private Rect spawnArea;
    
    private void Awake()
    {
        spawnArea = new Rect(
            Mathf.Min(cornerPoint1.position.x, cornerPoint2.position.x),
            Mathf.Min(cornerPoint1.position.y, cornerPoint2.position.y),
            Mathf.Abs(cornerPoint1.position.x - cornerPoint2.position.x),
            Mathf.Abs(cornerPoint1.position.y - cornerPoint2.position.y)
            );
    }

    private void Start()
    {
        SpawnEnemyAtRandomPoints(3);
    }

    private void SpawnEnemyAtRandomPoints(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnArea.RandomPoint(),
                Quaternion.identity, monsterSpawnParent);

            GameObject hpBar = Instantiate(hpBarSliderPrefab, hpBarSpawnParent);
            hpBar.GetComponent<HealthBar>().SetMaxHealth(enemyHp);
            hpBar.GetComponent<HealthBar>().SetTrackableHealth(enemy.GetComponent<Enemy>().Health);
            hpBar.GetComponent<WorldToUi>().SetTarget(enemy.transform);
            hpBar.GetComponent<WorldToUi>().SetOffsetY(hpBarOffsetY);
        }
    }
}
