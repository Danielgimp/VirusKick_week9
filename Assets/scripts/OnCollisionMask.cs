using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionMask : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Virus"  && enabled)
        {

            Destroy(collision.gameObject);

        }

    }
}
