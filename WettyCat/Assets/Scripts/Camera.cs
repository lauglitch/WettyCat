using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float initalYPos;

    void Start()
    {
        initalYPos = transform.position.y;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, initalYPos, transform.position.z);
    }
}
