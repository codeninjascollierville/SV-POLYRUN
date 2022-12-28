using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreIncreasePerSecond : MonoBehaviour
{
    public static int scoreValue;
    public Text score;
    public Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + scoreValue;

        if(scoreValue > PlayerPrefs.GetInt("HighScore", 0))
        {
            highScore.text = "" + scoreValue;
            PlayerPrefs.SetInt("HighScore", scoreValue);
        }
        
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        highScore.text = "0";
    }
}
