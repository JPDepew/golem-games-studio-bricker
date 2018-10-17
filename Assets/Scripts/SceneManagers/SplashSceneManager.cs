using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashSceneManager : MonoBehaviour
{
    public Animator animator;

    float timer = 0;
    float targetTime = 0;

    private void Start()
    {
        targetTime = animator.GetCurrentAnimatorStateInfo(0).length;

        StartCoroutine(ChangeScene());
    }

    void Update()
    {

    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(targetTime);
        SceneManager.LoadScene(2);
    }
}
