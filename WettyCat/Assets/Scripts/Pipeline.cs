using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    public Vector2 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    void OnBecameInvisible()
    {
        transform.parent.transform.parent.GetComponent<PipelineHandler>().pushPipeline();
    }

}
