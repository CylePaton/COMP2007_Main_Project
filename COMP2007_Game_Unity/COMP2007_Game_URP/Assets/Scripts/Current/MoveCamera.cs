using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    //This code simply set the camera position to an empty camera holder object
    [SerializeField] Transform cameraPositon;

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPositon.position;
    }
}
