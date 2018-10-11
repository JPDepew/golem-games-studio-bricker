using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    public Text scoreText;

    int score = 0;
    float timer = 0;

    private void Start()
    {
        scoreText.text = "Score: " + score;
        StartCoroutine(ChangeScene());
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            score += 10;
        }
        scoreText.text = "Score: " + score;
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(5);
        if (Constants.S.highScore < score)
        {
            Constants.S.SetHighScore(score);
        }
        SceneManager.LoadScene(2);
    }
}
