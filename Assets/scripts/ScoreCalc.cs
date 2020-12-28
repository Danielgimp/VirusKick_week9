using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreCalc : MonoBehaviour
{   
    private GameManager gameM;
    
    private TMP_Text scoreText;

    private void Start()
    {
        gameM = GameManager.Instance;
        scoreText = GetComponent<TMP_Text>();
    }
       
    // Update is called once per frame
    void Update()
    {
        if(gameM.startGame)
        {           
            scoreText.text = "Score: "+gameM.Score.ToString(); //distance show on canvas
        }  
        
    }
}
