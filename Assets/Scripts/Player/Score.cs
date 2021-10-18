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
    public static Score Instance;
    [Header("Dont touch")]
    public int score;
    public int highScore;
    public int totalShotCount;
    public int headShotCount;
    public int bodyShotCount;
    public int legShotCount;
    public int missedShotCount;
    public string trainingHighScore;
    [Header("References")]
    [SerializeField] Text scoreText;
    #endregion

    #region Awake
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    #region Start
    private void Start()
    {
        Reset();
        // Get high score
        trainingHighScore = TrainingSelection.Instance.trainingSelection + TrainingSelection.Instance.timer;
        highScore = PlayerPrefs.GetInt(trainingHighScore, 0);
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
        PlayerPrefs.SetInt(trainingHighScore, highScore);
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
