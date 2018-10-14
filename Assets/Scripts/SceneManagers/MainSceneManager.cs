using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    public GameObject ball;

    float timer = 0;

    void Update()
    {
        scoreText.text = "Score: " + Constants.S.score;
        livesText.text = "Lives: " + Constants.S.lives;
    }

    public void OnBallDestroyed()
    {
        Constants.S.lives--;
        if(Constants.S.lives <= 0) // game over
        {
            if (Constants.S.highScore < Constants.S.score)
            {
                Constants.S.SetHighScore(Constants.S.score);
            }
            SceneManager.LoadScene(1);
        }
        else // respawn ball
        {
            StartCoroutine(RespawnBall());
        }
    }

    IEnumerator RespawnBall()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(ball);
    }
}
