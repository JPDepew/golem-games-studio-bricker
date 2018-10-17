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

    private void Awake()
    {
    }

    private void Start()
    {
        StartCoroutine(RespawnBall());
        blocksCount = FindObjectsOfType<Block>().Length;
    }

    void Update()
    {
        scoreText.text = "Score: " + Data.Instance.score;
        livesText.text = "Lives: " + Data.Instance.lives;
        Block.onBlockDestroyed += OnBlockDestroyed;
    }

    public void OnBallDestroyed()
    {
        Data.Instance.lives--;
        if (Data.Instance.lives <= 0) // game over
        {
            if (Constants.S.highScore < Data.Instance.score)
            {
                Constants.S.SetHighScore(Data.Instance.score);
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
            SceneManager.LoadScene(1); // Game Over
        }
    }

    IEnumerator RespawnBall()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(ball);
    }
}
