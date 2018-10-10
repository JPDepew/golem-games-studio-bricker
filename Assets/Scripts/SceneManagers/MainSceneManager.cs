using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    public Text scoreText;

    int score = 0;
    float timer = 0;

    private void Start()
    {
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            score += 10;
        }
        scoreText.text = "Score: " + score;
        timer += Time.deltaTime;
        if (timer > 5)
        {
            if(Constants.S.highScore < score)
            {
                Constants.S.SetHighScore(score);
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
}
