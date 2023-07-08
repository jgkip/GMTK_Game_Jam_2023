using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action<int> OnNewWave;
    [SerializeField] private int waveCount;

    private void OnEnable()
    {
        EnemySpawner.OnEnemiesDead += UpdateWaveCount;
    }

    private void OnDisable()
    {
        EnemySpawner.OnEnemiesDead -= UpdateWaveCount;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateWaveCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateWaveCount()
    {
        waveCount += 1;
        OnNewWave?.Invoke(GetWaveCount());
    }

    public int GetWaveCount()
    {
        return waveCount;
    }
}
