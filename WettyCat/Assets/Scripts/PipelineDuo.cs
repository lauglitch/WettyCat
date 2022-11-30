using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelineDuo : MonoBehaviour
{
    public GameHandler gamehandler;

    // Check collision with Player
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            gamehandler.addScore();
        }
    }
}
