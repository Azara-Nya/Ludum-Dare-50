using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sleeper : MonoBehaviour
{
    [SerializeField] private GameObject Blackout;
    [SerializeField] private Animator BOC;
    [SerializeField] private float MaxTime = 15f;
    [SerializeField] private AudioSource As;
    [SerializeField] private Menu mn;
    public float timer = 0f;
    public bool IsAsleep = false;
    private bool gate;

    void Start()
    {
        Blackout.SetActive(false);
    }
    public void Sleping()
    {
        IsAsleep = !IsAsleep;
    }

    void Update()
    {
        if (mn.CanPlay)
        {
            if (timer < 0)
            {
                timer = 0f;
            }
            else if (timer >= MaxTime)
            {
                IsAsleep = true;
                StartCoroutine(SFXER());
                Blackout.SetActive(true);
                BOC.SetBool("EndWork", true);
            }
            else
            {
                timer += Time.fixedDeltaTime;
            }
        }
        else
        {
            timer = 0f;
            gate=false;
        }
    }

    IEnumerator SFXER()
    {
        if(!gate)
        {
            As.Play();
            yield return new WaitForSeconds(As.clip.length);
            gate=true;
        }
    }
}
