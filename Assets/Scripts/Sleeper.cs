using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sleeper : MonoBehaviour
{
    [SerializeField] private GameObject Blackout;
    [SerializeField] private float MaxTime = 15f;
    public float timer = 0f;
    public bool IsAsleep = false;

    void Start()
    {
        Blackout.SetActive(false);
    }

    void Update()
    {
        if (timer < 0)
        {
            timer = 0f;
        }
        else if (timer >= MaxTime)
        {
            Blackout.SetActive(true);
            IsAsleep = true;
        }
        else
        {
            timer += Time.fixedDeltaTime;
        }
    }
}
