using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionMask : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: "+collision.gameObject.name);
        if (collision.gameObject.name.Contains("Blue") || collision.gameObject.name.Contains("Green") ||
            collision.gameObject.name.Contains("Red") || collision.gameObject.name.Contains("Yellow"))
        {
            Debug.Log("Colision Detected!");
            Destroy(collision.gameObject);
            Destroy(this);
            
            
        }

    }
}
