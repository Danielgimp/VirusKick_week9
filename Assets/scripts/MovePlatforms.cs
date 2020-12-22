using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
   [SerializeField] float forwardSpeed = 20f;

    private GameManager gameM;
    private Vector3 initLocation;

    private void Start()
    {
        initLocation = transform.position;       
        gameM = GameManager.Instance;
        GameManager.onGameStart += Reset;
    }

    void Update()
    {       
        transform.position= transform.position+ transform.forward * forwardSpeed * Time.deltaTime * gameM.CurrentGameSpeed;
    }

    private void Reset()
    {
        transform.position = initLocation;
     
    }
}
