using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverSceneManager : MonoBehaviour
{
    public Text highScoreText;

    float timer = 0;

    private void Start()
    {
        highScoreText.text = "High Score: " + Constants.S.highScore.ToString();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }
}
