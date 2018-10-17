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
    public float waitToLoadNextSceneTime = 1f;

    int blocksCount = 0;
    int blocksDestroyed;

    private void Start()
    {
        StartCoroutine(RespawnBall());
        blocksCount = FindObjectsOfType<Block>().Length;
    }

    void Update()
    {
        scoreText.text = "Score: " + Constants.S.score;
        livesText.text = "Lives: " + Constants.S.playerLives;
        Block.onBlockDestroyed += OnBlockDestroyed;
    }

    public void OnBallDestroyed()
    {
        Constants.S.playerLives--;
        if (Constants.S.playerLives <= 0) // game over
        {
            if (Constants.S.highScore < Constants.S.score)
            {
                Constants.S.SetHighScore(Constants.S.score);
            }
            SceneManager.LoadScene(1); // Game Over Scene
        }
        else // respawn ball
        {
            StartCoroutine(RespawnBall());
        }
    }

    public void OnBlockDestroyed()
    {
        Block.onBlockDestroyed -= OnBlockDestroyed;
        blocksDestroyed++;
    
        if(blocksDestroyed >= blocksCount)
        {
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(waitToLoadNextSceneTime);
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator RespawnBall()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(ball);
    }
}
