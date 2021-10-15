using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * This script is for managing the game
 * Includes timer, win conditions, etc
 */
public class GameManager : MonoBehaviour
{
    #region Variables
    int timer;
    float ticks;
    [Header("References")]
    [SerializeField] GameObject endMenu;
    [SerializeField] Text timerText;
    [SerializeField] Text scoreText;
    [SerializeField] Text highScoreText;
    [SerializeField] Text totalShotCountText;
    [SerializeField] Text headShotCountText;
    [SerializeField] Text bodyShotCountText;
    [SerializeField] Text legShotCountText;
    [SerializeField] Text missedShotCountText;
    #endregion

    #region Start
    private void Start()
    {
        // Set the timer to the timer the player choses
        timer = TrainingSelection.Instance.timer;
    }
    #endregion

    #region Update
    private void Update()
    {
        // Display timer
        timerText.text = "Timer: " + timer;
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EndGame();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Score.Instance.highScore = 0;
            // Call the SetHighScore function
            Score.Instance.SetHighScore();
        }
#endif
        // Timer
        if (timer > 0)
        {
            if (ticks < 1)
            {
                ticks += Time.deltaTime;
            }
            else
            {
                ticks = 0;
                timer--;
            }
        }
        else
        {
            EndGame();
        }
    }
    #endregion

    #region EndGame
    private void EndGame()
    {
        PauseMenu.paused = true;
        // Show cursor
        Cursor.visible = true;
        // Unlock cursor
        Cursor.lockState = CursorLockMode.None;
        // Set time scale to 0
        Time.timeScale = 0;
        // Show pause menu
        endMenu.SetActive(true);

        #region Display Scores
        // If score is higher than highscore
        if (Score.Instance.score > Score.Instance.highScore)
        {
            // Call the SetHighScore function
            Score.Instance.SetHighScore();
        }
        // Set text
        scoreText.text = "Score: " + Score.Instance.score;
        highScoreText.text = "High Score: " + Score.Instance.highScore;
        totalShotCountText.text = "Total Shot Count: " + Score.Instance.totalShotCount;
        headShotCountText.text = "Head Shot Count: " + Score.Instance.headShotCount;
        bodyShotCountText.text = "Body Shot Count: " + Score.Instance.bodyShotCount;
        legShotCountText.text = "Leg Shot Count: " + Score.Instance.legShotCount;
        missedShotCountText.text = "Missed Shot Count: " + Score.Instance.missedShotCount;
        #endregion
    }
    #endregion
}
