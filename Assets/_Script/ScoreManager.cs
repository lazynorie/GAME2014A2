///By Jing Yuan Cheng 101257237
/// ScoreManager Script
/// 
/// Version 1.0
/// Last edited on Dec 11 2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Score:" + 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score:" + score.ToString();
    }
    
}
