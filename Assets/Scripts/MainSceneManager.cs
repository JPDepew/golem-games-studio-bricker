using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    public Text highScoreText;

    float timer = 0;

    private void Start()
    {
        highScoreText.text = "High Score: " + Constants.S.score.ToString();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
}
