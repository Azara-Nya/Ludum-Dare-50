using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] SpawnPoints;
    [SerializeField] private GameObject Coffee;
    [SerializeField] private GameObject Work;
    [SerializeField] private float MinTime = 0.1f;
    [SerializeField] private float MaxTime = 5f;
    private GameObject SpawnerPoint;
    private int index;
    private bool IsWork = false;
    private float spawnDelay;
    Work Wk;
    void Start()
    {
        Invoke("Spanwer", 2f);
    }

    void Spanwer()
    {
        index = Random.Range(0, SpawnPoints.Length);
        SpawnerPoint = SpawnPoints[index];
        spawnDelay = Random.Range(MinTime, MaxTime);

        Instantiate(Coffee, SpawnerPoint.transform.position, Quaternion.identity);
        if (!IsWork)
        {
            Instantiate(Work, SpawnerPoint.transform.position, Quaternion.identity);
            IsWork = true;
        }
        Invoke("Spanwer", spawnDelay);
    }
    void Update()
    {
        Wk = FindObjectOfType<Work>();
        if (Wk.PingTime)
        {
            IsWork = false;
        }
    }

}
