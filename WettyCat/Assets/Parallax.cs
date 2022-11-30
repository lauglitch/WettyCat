using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed;
    public Vector2 originalPosition;
    private float offset = 4.83f;
    public bool moving;

    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        speed = -0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
            transform.position = new Vector2(transform.position.x + Time.deltaTime * speed, transform.position.y);
    }

    void OnBecameInvisible()
    {
        transform.position = new Vector2(transform.parent.transform.position.x + offset, transform.position.y);
    }
}
