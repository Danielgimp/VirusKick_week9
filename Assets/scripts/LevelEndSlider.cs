using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEndSlider : MonoBehaviour
{
    private Slider levelEndSlider;
    public float sliderFillRate = 0.04f;
    private float SecondsInMinute = 60;
    private GameManager gameManager;

    private void Awake()
    {
        levelEndSlider = GameObject.Find("LevelEndBar").GetComponent<Slider>();
        
    }

    public void IncreaseLevelProgress()
    {
        StartCoroutine(IncreaseLevelProgress(levelEndSlider));
    }

    IEnumerator IncreaseLevelProgress(Slider slider)
    {
        if (slider != null)
        {
            
            float timeSlice = sliderFillRate * (Time.deltaTime/ SecondsInMinute);
            while (slider.value < 1f)
            {
                Debug.Log("Reached While Loop");
                slider.value += timeSlice;
                yield return new WaitForSeconds(1);
                if (slider.value >= 1)
                {
                    Debug.Log("Reached If Statement"); 
                    break;
                }
            }
           



        }
        yield return null;
    }


}
