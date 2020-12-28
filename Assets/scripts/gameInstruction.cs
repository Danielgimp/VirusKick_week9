using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameInstruction : MonoBehaviour
{
    public void LoadInstruction()
    {
        SceneManager.LoadScene("GameInstructions");

    }
}
