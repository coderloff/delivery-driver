using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform theDarker;

    void LateUpdate()
    {
        transform.position = theDarker.position + new Vector3(0,0,-10);        
    }
}
