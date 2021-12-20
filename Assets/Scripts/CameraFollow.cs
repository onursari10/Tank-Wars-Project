using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 CamPos;
    bool LookAt = true;
    
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        transform.position = player.position + CamPos;

        if (LookAt)
        {
            transform.LookAt(player);
        }
        else
        {
            transform.rotation = player.rotation;
        }
        
    }
}
