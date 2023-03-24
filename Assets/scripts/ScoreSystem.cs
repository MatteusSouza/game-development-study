using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public Text totalScoreTxt;
    public Text currentScoreTxt;
    private int totalScore;
    public static int currentScore;
    public static bool save;
    

    void Start()
    {
        save = false;
        currentScore = 0;
        totalScore = PlayerPrefs.GetInt("totalScore");
    }

    void Update()
    {
        currentScoreTxt.text = currentScore.ToString();
        
        if (totalScoreTxt != null){
            totalScoreTxt.text = totalScore.ToString();
        }
        playerManager.onRestartLevel += ResetScore;
        saveScore();
    }
    
    private void ResetScore()
    {
        currentScore = 0;
    }

    private void saveScore()
    {
        if (save == true)
        {
            int sumScore = totalScore + currentScore;
            PlayerPrefs.SetInt("totalScore", sumScore);
            PlayerPrefs.Save();
        }
    }
}
