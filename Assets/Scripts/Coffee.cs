using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Coffee : MonoBehaviour
{
    [SerializeField] private float CoffeePower = 2f;
    [SerializeField] private AudioSource AS;
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
            StartCoroutine(SFXER());
        }
    }

    IEnumerator SFXER()
    {
        Giorno = false;
        Sz.timer -= CoffeePower;
        AS.Play();
        yield return new WaitForSeconds(AS.clip.length);
        Destroy(gameObject);
    }
}
