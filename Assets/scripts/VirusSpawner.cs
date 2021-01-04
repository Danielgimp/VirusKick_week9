using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    public static VirusSpawner Instance { get; set; }

    [SerializeField]
    private List<GameObject> platformsViruses = new List<GameObject>();
    [SerializeField]
    private int amountToPool; //limit the Platforms amount

    private List<GameObject> platformPooled;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        platformPooled = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(platformsViruses[Random.Range(0, platformsViruses.Count)]);   //pick Randomaly type of tile. (useful for the next scenarious)        
            obj.SetActive(false);
            platformPooled.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        int i = Random.Range(0, platformPooled.Count);

        if (!platformPooled[i].activeInHierarchy) //check if this platform is already active (to avoid duplications)
        {
            return platformPooled[i];
        }
        else
        {
            return GetPooledObject();
        }

    }

    public void ActiveFalseAllObject()
    {
        for (int i = 0; i < platformPooled.Count; i++)
        {
            platformPooled[i].SetActive(false);
        }
    }
}
