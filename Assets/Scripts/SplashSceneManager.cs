using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashSceneManager : MonoBehaviour
{
    public Text highScoreText;

    float timer = 0;

    private void Start()
    {
        highScoreText.text = "Score: " + Constants.S.score.ToString();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }
}
