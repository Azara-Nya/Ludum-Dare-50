using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static int Points = 0;
    private int score;
    [SerializeField] private TextMeshProUGUI Text;
    void Awake()
    {
        Points = 0;
    }


    void Update()
    {
        score = Points;
        Text.text = $"Score: {score}";
    }
}
