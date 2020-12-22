using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{    

    public bool isGrounded { get; set; }
    private GameManager gameM;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag =="Ground")
        {            
            isGrounded = true;
        }
        if (collision.transform.tag=="VirusReset")
        {
            gameM = GameManager.Instance;  // definition of GameManager
            gameM.ResetLevel(); //reset objects
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {           
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {          
            isGrounded = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
