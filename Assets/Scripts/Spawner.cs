using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] SpawnPoints;
    [SerializeField] private GameObject[] SpawnPointsW;
    [SerializeField] private GameObject Coffee;
    [SerializeField] private GameObject Work;
    [SerializeField] private float MinTime = 1.75f;
    [SerializeField] private float MaxTime = 3.5f;
    [SerializeField] private float MinTimeC = 3f;
    [SerializeField] private float MaxTimeC = 3.5f;
    [SerializeField] private int MaxCoffee = 3;
    [SerializeField] private int MaxWork = 3;
    private GameObject SpawnerPoint;
    private GameObject SpawnerPointW;
    private int index;
    private int indexW;
    public bool IsWork = false;
    private float spawnDelay = 1f;
    private float spawnDelayCoffee;
    private int CoffeeCounter;
    private int WorkCount;
    Work Wk;
    Coffee Ce;
    Sleeper Sz;
    void Start()
    {
        Invoke("Spanwer", 2f);
        index = Random.Range(0, SpawnPoints.Length);
        indexW = Random.Range(0, SpawnPoints.Length);
    }

    void Update()
    {
        Wk = FindObjectOfType<Work>();
        if (Wk == null)
        {
            if (WorkCount == MaxWork)
            {
                IsWork = false;
                WorkerS();
                WorkCount = 0;
            }
        }
        Ce = FindObjectOfType<Coffee>();
        if (Ce == null)
        {
            if (CoffeeCounter == MaxCoffee)
            {
                Spanwer();
                CoffeeCounter = 0;
            }
        }
    }
    void Spanwer()
    {
        index = Random.Range(0, SpawnPoints.Length);
        SpawnerPoint = SpawnPoints[index];
        spawnDelayCoffee = Random.Range(MinTimeC, MaxTimeC);
        if (CoffeeCounter != MaxCoffee)
        {
            Instantiate(Coffee, SpawnerPoint.transform.position, Quaternion.identity);
            CoffeeCounter++;
        }

        Invoke("WorkerS", spawnDelay);
    }
    void WorkerS()
    {
        if (IsWork == false)
        {
            indexW = Random.Range(0, SpawnPointsW.Length);
            SpawnerPointW = SpawnPointsW[indexW];
            spawnDelay = Random.Range(MinTime, MaxTime);
            if (WorkCount != MaxWork)
            {
                Instantiate(Work, SpawnerPointW.transform.position, Quaternion.identity);
                WorkCount++;
            }

            Invoke("Spanwer", spawnDelayCoffee);
        }
    }

}
