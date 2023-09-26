using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterSpawner : MonoBehaviour
{
    [Header("Enemy prefabs")]
    [SerializeField] private GameObject[] enemyPrefabs;
    
    [Header("SpawnArea cornerPoints")]
    [SerializeField] private Transform cornerPoint1;
    [SerializeField] private Transform cornerPoint2;
    
    [Header("SpawnParent")]
    [SerializeField] private Transform spawnParent;
    
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
            Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnArea.RandomPoint(),
                Quaternion.identity, spawnParent);
        }
    }
}
