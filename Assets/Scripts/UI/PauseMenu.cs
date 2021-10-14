using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script is used for pausing and unpausing
 */
public class PauseMenu : MonoBehaviour
{
    #region Variables
    public static bool paused;
    [Header("References")]
    [SerializeField] GameObject pauseMenu;
    #endregion

    #region Start
    private void Start()
    {
        UnPause();
    }
    #endregion

    #region Pause
    public void Pause()
    {
        paused = true;
        // Show cursor
        Cursor.visible = true;
        // Unlock cursor
        Cursor.lockState = CursorLockMode.None;
        // Set time scale to 0
        Time.timeScale = 0;
        // Show pause menu
        pauseMenu.SetActive(true);
    }
    #endregion

    #region UnPause
    public void UnPause()
    {
        paused = false;
        // Hide cursor
        Cursor.visible = false;
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        // Set time scale to 1
        Time.timeScale = 1;
        // Hide pause menu
        pauseMenu.SetActive(false);
    }
    #endregion

    #region MainMenu
    public void MainMenu()
    {
        // Set time scale to 1
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    #endregion

    #region ExitGame
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    #endregion

    #region Update
    private void Update()
    {
        // Pause and unpause with the escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            if (paused)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
    }
    #endregion
}
