using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static int Points = 0;
    private int score;
    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private Sleeper Sz;
    void Start()
    {
        Points = 0;
    }


    void Update()
    {
        if (!Sz.IsAsleep)
        {
            score = Points;
            Text.text = $"Score: {score}";
        }
        else
        {
            Points = 0;
        }
    }
}
