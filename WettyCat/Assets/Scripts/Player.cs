using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameHandler gamehandler;
    public float speed_x;
    public bool alive;
    public GameObject topLimit;
    public GameObject bottomLimit;
    public Vector2 originalPosition;
    public bool pipelineCollision;

    private void Awake()
    {

    }

    void Start()
    {
        originalPosition = transform.position;
        pipelineCollision = false;
        alive = false;
        gamehandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>();
        topLimit = GameObject.FindGameObjectWithTag("topLimit");
        bottomLimit = GameObject.FindGameObjectWithTag("bottomLimit");
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //firstTap = true;
    }

    void Update()
    {
        if (alive)
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 1.0f);
                GetComponent<Animator>().SetBool("swim", true);
                gamehandler.playPlayerSfx(0);
            } else
                GetComponent<Animator>().SetBool("swim", false);
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed_x, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void LateUpdate()
    {
        checkLimits();
    }

    public void setAlive()
    {
        alive = true;
        speed_x = 0.7f;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }
    void playIdleAnimation() 
    {
        GetComponent<Animator>().SetBool("swim", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (alive)
        {
            gamehandler.playPlayerSfx(1);
            speed_x = 0.0f;
            alive = false;
            gamehandler.gameOver();
            pipelineCollision = true;

            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void checkLimits()
    {
        if (alive)
            if (transform.position.y > topLimit.transform.position.y || 
                transform.position.y < bottomLimit.transform.position.y)
            {
                speed_x = 0.0f;
                alive = false;
                gamehandler.gameOver();
            }
    }

    public void restartPlayer()
    {
        pipelineCollision = false;
        alive = false;
        transform.position = originalPosition;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnBecameInvisible()
    {
        if (!pipelineCollision)
            gamehandler.playPlayerSfx(1);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
