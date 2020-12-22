using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject platform0;

    [SerializeField]
    private GameObject startPlatform;

    [SerializeField]
    private int sizePlatformZ=40;

    private Transform previousPlatform;
    private GameManager gameM;

    private float timer=0;
    [SerializeField] private float max_timer = 0.5f;

   
    // Start is called before the first frame update
    void Start()
    {
        gameM = GameManager.Instance;  // definition of GameManager
        GameManager.onGameStart += Reset; //reset objects
    }

    private void Reset()
    {
        startPlatform.SetActive(true);  //show first platform
        previousPlatform = platform0.transform; //define this platform as previous
        PlatformPooler.Instance.ActiveFalseAllObject(); //create new platforms 
    }

    private void Update()
    {
        if (gameM.startGame)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = max_timer / gameM.CurrentGameSpeed;
                createPlatforms();
            }
        }
    }

    private void createPlatforms()
    {
        GameObject platform = PlatformPooler.Instance.GetPooledObject();
        if (platform != null)
        {
            platform.transform.position = new Vector3(0, 0, previousPlatform.position.z + sizePlatformZ);
            previousPlatform = platform.transform;
            platform.SetActive(true);
        }
    }
}


