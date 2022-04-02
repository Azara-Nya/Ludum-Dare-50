using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour
{
    [SerializeField] private float CoffeePower = 2f;
    private bool Giorno = false;
    Sleeper Sz;

    void Awake()
    {
        Sz = FindObjectOfType<Sleeper>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Giorno = true;
        }
    }
    void Update()
    {
        if (Giorno)
        {
            Sz.timer -= CoffeePower;
            Destroy(gameObject);
        }
    }

}
