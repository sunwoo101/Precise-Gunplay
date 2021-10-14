using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This script stores the scores
 */
public class Score : MonoBehaviour
{
    #region Varaibles
    public static Score ScoreInstance;
    public static int score;
    public static int highScore;
    public static int totalShotCount;
    public static int headShotCount;
    public static int bodyShotCount;
    public static int legShotCount;
    public static int missedShotCount;
    [Header("References")]
    [SerializeField] Text scoreText;
    #endregion

    #region Awake
    private void Awake()
    {
        ScoreInstance = this;
    }
    #endregion

    #region Start
    private void Start()
    {
        Reset();
        // Get high score
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }
    #endregion

    #region Update
    private void Update()
    {
        // Display score
        scoreText.text = "Score: " + score;
    }
    #endregion

    #region SetHighScore
    public void SetHighScore()
    {
        // Set high score
        highScore = score;
        PlayerPrefs.SetInt("highScore", highScore);
    }
    #endregion

    #region Reset
    public void Reset()
    {
        totalShotCount = 0;
        score = 0;
        headShotCount = 0;
        bodyShotCount = 0;
        legShotCount = 0;
        missedShotCount = 0;
    }
    #endregion
}
