using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Work : MonoBehaviour
{
    [SerializeField] private float MaxTime = 3f;
    [SerializeField] private float timer;
    [SerializeField] private Animator Andy;
    bool AdvanceTime = false;


    void Start()
    {
        Andy.speed = 0;
    }
    void Update()
    {
        if (AdvanceTime)
        {
            if (timer >= MaxTime)
            {
                Score.Points++;
                Debug.Log("Ding");
                Destroy(gameObject);
            }
            else
            {
                timer += Time.fixedDeltaTime;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AdvanceTime = true;
            Andy.speed = 1;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AdvanceTime = false;
            Andy.speed = 0;
        }
    }

}