using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sleeper : MonoBehaviour
{
    [SerializeField] private GameObject Blackout;
    [SerializeField] private float MaxTime = 15f;
    private float timer = 0f;
    public bool IsAsleep = false;

    void Start()
    {
        timer = -2f;
        Blackout.SetActive(false);
    }

    void Update()
    {
        Debug.Log(timer);
        if (timer >= MaxTime)
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
