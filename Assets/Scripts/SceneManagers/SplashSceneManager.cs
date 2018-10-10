using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashSceneManager : MonoBehaviour
{
    public Text highScoreText;
    public Animator animator;

    float timer = 0;
    float targetTime = 0;

    private void Start()
    {
        highScoreText.text = "High Score: " + Constants.S.highScore.ToString();
        targetTime = animator.GetCurrentAnimatorStateInfo(0).length;// highScoreText.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        Debug.Log(targetTime);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > targetTime)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }
}
