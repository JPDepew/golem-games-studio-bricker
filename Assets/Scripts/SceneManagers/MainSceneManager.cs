using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    public Text pressSpaceText;
    public GameObject ball;
    public GameObject player;
    public Transform playerSpawnPoint;
    public float waitToLoadNextSceneTime = 1f;

    int blocksCount = 0;
    int blocksDestroyed;
    bool canRespawnBall = true;

    private void Start()
    {
        blocksCount = FindObjectsOfType<Block>().Length;
        player = Instantiate(player, playerSpawnPoint.position, transform.rotation);
    }

    void Update()
    {
        scoreText.text = "Score: " + Data.Instance.score;
        livesText.text = "Lives: " + Data.Instance.lives;

        if (canRespawnBall && Input.GetKeyDown(KeyCode.Space))
        {
            ball = Instantiate(ball, new Vector2(player.transform.position.x, player.transform.position.y + 0.5f), transform.rotation);
            canRespawnBall = false;
            pressSpaceText.enabled = false;
        }
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
            pressSpaceText.enabled = true;
            canRespawnBall = true;
        }
    }

    public void OnBlockDestroyed()
    {
        blocksDestroyed++;

        if (blocksDestroyed >= blocksCount)
        {
            Destroy(ball);
            StartCoroutine(LoadNextScene());
            if (Constants.S.highScore < Data.Instance.score)
            {
                Constants.S.SetHighScore(Data.Instance.score);
            }
        }
        if (Data.Instance.scoreCounter >= 500)
        {
            Data.Instance.scoreCounter -= 500;
            Data.Instance.lives++;
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
}
