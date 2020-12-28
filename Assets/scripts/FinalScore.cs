using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FinalScore : MonoBehaviour
{
    private GameManager gameM;

    private TMP_Text scoreText;
    private float score;    

    private void Start()
    {
        gameM = GameManager.Instance;
        scoreText = GetComponent<TMP_Text>();
        score = GameManager.Instance.CurrentGameSpeed;
        scoreText.text = $"High Score: 0";
        GameManager.onGameEnd += SetScore;
    }

    private void SetScore()
    {
        scoreText.text = $" High Score: {gameM.Score}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
