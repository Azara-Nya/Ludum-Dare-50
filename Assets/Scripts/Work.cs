using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Work : MonoBehaviour
{
    [SerializeField] private float MaxTime = 3f;
    [SerializeField] private float timer;
    bool AdvanceTime = false;

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
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AdvanceTime = false;
        }
    }

}