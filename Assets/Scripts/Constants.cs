using UnityEngine;

public class Constants : MonoBehaviour
{
    public string playerPrefHighScoreKey = "playerHighScore";
    public int score = 0;
    static public Constants S;

    private void Awake()
    {
        S = this;

        if (PlayerPrefs.HasKey(playerPrefHighScoreKey))
        {
            score = PlayerPrefs.GetInt(playerPrefHighScoreKey);
        }
        else
        {
            Debug.Log(score);
            PlayerPrefs.SetInt(playerPrefHighScoreKey, score);
        }
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
