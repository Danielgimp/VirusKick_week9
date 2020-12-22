using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollsion : MonoBehaviour
{    

    public delegate void OnCollision();
    public static event OnCollision onCollision;
    private GameManager gameM;

    // Start is called before the first frame update
    void Start()
    {
        gameM = GameManager.Instance;  // definition of GameManager

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        transform.parent.gameObject.SetActive(false);
        onCollision();
        if (other.transform.tag == "VirusReset")
        {
            gameM = GameManager.Instance;  // definition of GameManager
            gameM.ResetLevel(); //reset objects
        }
    }
}
