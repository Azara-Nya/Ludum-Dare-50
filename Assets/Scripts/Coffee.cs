using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour
{
    [SerializeField] private float CoffeePower = 3f;
    Sleeper Sz;

    void Awake()
    {
        Sz = FindObjectOfType<Sleeper>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Sz.timer -= CoffeePower;
            Destroy(gameObject);
        }
    }
}
