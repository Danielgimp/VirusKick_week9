using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasBoardManager : MonoBehaviour
{
    private GameManager gameM;

    public GameObject menu;
    public TMP_Text score;
    public TMP_Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        gameM = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameM.startGame) //when game is running - show just the score text.
        {
            menu.SetActive(false);
            score.gameObject.SetActive(true);
            highScore.gameObject.SetActive(false);
        }
        else //when startGame==false , show all canvas texts. also  the high score and the introduction.
        {
            menu.SetActive(true);
            score.gameObject.SetActive(false);
            highScore.gameObject.SetActive(true);
        } 
    }
}
