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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(2);
        }
    }
}