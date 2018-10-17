using UnityEngine;
using UnityEngine.SceneManagement;

public class Constants : MonoBehaviour
{
    public string playerPrefHighScoreKey = "playerHighScore";
    public int highScore = 0;
    public int score = 0;
    public int playerLives = 3;
    public float playerSpeed = 0.2f;

    static public Constants S;

    private void Awake()
    {
        S = this;

        if (PlayerPrefs.HasKey(playerPrefHighScoreKey))
        {
            highScore = PlayerPrefs.GetInt(playerPrefHighScoreKey);
        }
        else
        {
            PlayerPrefs.SetInt(playerPrefHighScoreKey, highScore);
        }
    }

    public void SetHighScore(int newHighScore)
    {
        highScore = newHighScore;
        PlayerPrefs.SetInt(playerPrefHighScoreKey, highScore);
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }
}
