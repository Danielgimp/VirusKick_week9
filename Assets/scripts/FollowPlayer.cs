using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 Offset = new Vector3(0, 7, -25);
    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + Offset;
    }
}
