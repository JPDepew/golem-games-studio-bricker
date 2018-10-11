using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSceneManager : MonoBehaviour
{
    public Text highScoreText;

    float timer = 0;

    private void Start()
    {
        highScoreText.text = "High Score: " + Constants.S.highScore.ToString();
        StartCoroutine(ChangeScene());
    }

    void Update()
    {

    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}
