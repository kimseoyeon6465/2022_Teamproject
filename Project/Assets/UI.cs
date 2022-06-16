using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI[] rankText;

    public static int score = 0;
    public float time = 15f;

    private int[] bestScore = new int[5];
    private int[] rankScore = new int[5];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer();
        scoreUpdate();

        //rankText.text = PlayerPrefs.GetInt("CurrentScore").ToString();

        for (int i = 0; i < 5; i++)
        {
            rankScore[i] = PlayerPrefs.GetInt(i + "BestScore");
            rankText[i].text = rankScore[i].ToString() + "Á¡";
        }
    }

    private void timer()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            setScore();
            time = 5f;
            score = 0;
        }
        timeText.text = Mathf.Ceil(time).ToString();
    }

    private void scoreUpdate()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void timeOver()
    {
        
    }

    void setScore()
    {
        //PlayerPrefs.SetInt("CurrentScore", score);

        int tmpScore = 0;

        for (int i = 0; i < 5; i++)
        {
            bestScore[i] = PlayerPrefs.GetInt(i + "BestScore");
            if (score > bestScore[i])
            {
                tmpScore = bestScore[i];
                bestScore[i] = score;

                PlayerPrefs.GetInt(i + "BestScore", score);

                score = tmpScore;
            }
        }
        for(int i=0; i<5; i++)
        {
            PlayerPrefs.SetInt(i + "BestScore", bestScore[i]);
        }
    }
}
