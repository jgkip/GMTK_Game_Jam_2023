using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static event Action OnEnemiesDead;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private int waveMultiplier;
    [SerializeField] private WorldData worldData;

    private void OnEnable()
    {
        GameManager.OnNewWave += SpawnEnemies;
    }

    private void OnDisable()
    {
        GameManager.OnNewWave -= SpawnEnemies;
    }

    // Start is called before the first frame update
    void Start()
    {

        SpawnEnemies(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckEnemyStatus()
    {
        if (enemyList.Count == 0)
        {
            OnEnemiesDead?.Invoke();
        }
    }

    private void UpdateEnemyList()
    {
        
    }

    private void SpawnEnemies(int waveCount)
    {
        Debug.Log("Spawn enemy event");
        
        for (int i = 0; i < waveMultiplier * waveCount; i++)
        {
            Vector2 spawnPos = worldData.RandSpawnPos();
            var enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            enemyList.Add(enemy);
        }
        
    }
}
