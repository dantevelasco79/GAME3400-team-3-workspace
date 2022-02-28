using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class LevelManager : MonoBehaviour
{
    public float levelDuration;
    public int score;
    public Text timerText;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        levelDuration = 300;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SetTimerText();
        SetScoreText();
        levelDuration -= Time.deltaTime;
    }

    // Set timerText to current countDown value
    void SetTimerText()
    {
        float minutes = Mathf.FloorToInt(levelDuration / 60);
        float seconds = Mathf.FloorToInt(levelDuration % 60);
        timerText.text = "Catch all the Fish - " + string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    // Set scoreText to current score value
    void SetScoreText() 
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
