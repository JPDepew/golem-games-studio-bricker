using UnityEngine;

public class Constants : MonoBehaviour
{
    public string playerPrefHighScoreKey = "playerHighScore";
    public int highScore = 0;
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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
