using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : MonoBehaviour
{    
    [SerializeField]
    private float SecondsToDisable = 40f;
    private float time = 0f;

    

    private void Start()
    {

        GameManager.onGameStart += Reset;
    }

    private void Reset()
    {
        time = 0f;
    }

    private void Update()  //set active as false the platforms after 40 sec.
    {
        time += Time.deltaTime;
        if(GameManager.Instance.CurrentGameSpeed!= 0)
        {
            if(time > SecondsToDisable / GameManager.Instance.CurrentGameSpeed)
            {
                SetactivateFalse();
                time = 0f;
            }
        }
    }

    public void SetactivateFalse()
    {
        gameObject.SetActive(false);
    }
}
