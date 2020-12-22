using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{ get; set; }

    [SerializeField]
    public float gameSpeedMin = 1f; //speed at start
    [SerializeField]
    public float gameSpeedMax = 1.5f; //Max speed
    [SerializeField]
    public float SpeedSteps = 500f; //increasing speed

    private GameObject Player;

    public float CurrentGameSpeed { get; set; } //increase speed by SpeedSteps
   

    public bool startGame { get; set; }

    public delegate void OnGameStart();   //check current event (for some methods)
    public static event OnGameStart onGameStart;
    public static event OnGameStart onGameEnd;

    public int Score { get; set; }
    public int HighScore{ get; set; }

    float timer = 0.0f;
    private Vector3 playerStart;

    private void Awake()
    {
        Instance = this;
        CurrentGameSpeed = 0;        
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerStart = Player.transform.position;
        startGame = false;
        StartCoroutine(WaitForSpace());
    }



    IEnumerator WaitForSpace() //waits until press space key.
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        GameStart();
    }

    private void GameStart()
    {
        onGameStart();
        CurrentGameSpeed = gameSpeedMin;
        startGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            timer += Time.deltaTime * CurrentGameSpeed;
             Score = Convert.ToInt32(timer);  //distance
            if (CurrentGameSpeed< gameSpeedMax)
                CurrentGameSpeed += Time.deltaTime / SpeedSteps;
        }
        if (Player.transform.position.y < 0)
        {
            ResetLevel();
        }
    }
    

    public void ResetLevel()
    {
        onGameEnd();
        Player.transform.position = playerStart;
        CurrentGameSpeed = 0;
        startGame = false;
        timer = 0;
        StartCoroutine(WaitForSpace());
    }
}
