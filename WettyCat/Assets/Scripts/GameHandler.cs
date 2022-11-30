using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public Player player;
    public PipelineHandler pipelineHandler;
    public float maxSpeed;
    public GameObject environmentSfx;
    public GameObject playerSfx;
    public GameObject gameover;
    public GameObject scoreText;
    public GameObject parallax1;
    public GameObject parallax2;
    public GameObject startButton;
    public GameObject restartButton;
    public GameObject titleText;
    private int score;

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        score = 0;
        maxSpeed = 3.0f;
        startButton.SetActive(true);
        gameover.SetActive(false);
        scoreText.SetActive(false);
        restartButton.SetActive(false);
    }

    public void startGame()
    {
        scoreText.SetActive(true);
        startButton.SetActive(false);
        titleText.SetActive(false);

        player.setAlive();

        parallax1.GetComponent<Parallax>().moving = true;
        parallax2.GetComponent<Parallax>().moving = true;
    }
    public void addScore()
    {
        playGameSfx(0);
        score += 1;
        scoreText.GetComponent<Text>().text = "Score: " + score;

        // Increase game speed when player has crossed 10 pipelines
        if (score%10 == 0 && player.speed_x <= maxSpeed)
        {
            player.speed_x += 0.1f;
        }
    }

    public void resetScore()
    {
        score = 0;
        scoreText.GetComponent<Text>().text = "Score:" + 0;
    }

    public void playGameSfx(int number)
    {
        environmentSfx.GetComponent<GameSFX>().playEffect(number);
    }
    public void playPlayerSfx(int number)
    {
        playerSfx.GetComponent<PlayerSFX>().playEffect(number);
    }
    

    public void gameOver()
    {
    gameover.SetActive(true);
    restartButton.SetActive(true);
    parallax1.GetComponent<Parallax>().moving = false;
    parallax2.GetComponent<Parallax>().moving = false;
    }

    public void restartGame()
    {
        resetScore();
        gameover.SetActive(false);
        restartButton.SetActive(false);

        player.restartPlayer();
        pipelineHandler.restartPipelines();

        player.setAlive();
        parallax1.GetComponent<Parallax>().moving = true;
        parallax2.GetComponent<Parallax>().moving = true;
    }
}
