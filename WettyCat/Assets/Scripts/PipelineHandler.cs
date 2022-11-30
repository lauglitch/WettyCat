using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelineHandler : MonoBehaviour
{
    public float offset_x;  //distance between two PipelineDuo in x axis
    public List<GameObject> pipelines;
    public float minHeight;
    public float maxHeight;

    void Start()
    {
        minHeight = -0.3f;
        maxHeight = 0.35f;

        offset_x = 1.0f;

        for (int i = 0; i < pipelines.Count; i++)
        {
            pipelines[i].transform.position = new Vector2(pipelines[i].transform.position.x, Random.Range(minHeight, maxHeight));
        }
    }

    // Moves pipeline to the end 
    public void pushPipeline()
    {
        pipelines[0].transform.position = new Vector2(pipelines[pipelines.Count - 1].transform.position.x
            + offset_x, Random.Range(minHeight, maxHeight));

        GameObject aux = pipelines[0];
        pipelines.RemoveAt(0);
        pipelines.Insert(pipelines.Count, aux);
    }

    // Set pipeline positions to original ones when restart game
    public void restartPipelines()
    {
        for (int i = 0; i < pipelines.Count; i++)
        {
            pipelines[i].transform.position = pipelines[i].GetComponentInChildren<Pipeline>().originalPosition;
            pipelines[i].transform.position = new Vector2(pipelines[i].transform.position.x, Random.Range(minHeight, maxHeight));
        }
    }
}
