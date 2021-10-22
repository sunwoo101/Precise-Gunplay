using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This script is for the Main Menu
 */
public class MainMenu : MonoBehaviour
{
    #region Variables
    [Header("References")]
    [SerializeField] InputField sensitivityInputField;
    [SerializeField] Slider sfxSlider;
    #endregion

    #region Start
    private void Start()
    {
        sensitivityInputField.text = Settings.Instance.mouseSensitivity.ToString();
        sfxSlider.value = Settings.Instance.sfxVolume;
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

    #region ChangeSensitivity
    public void ChangeSensitivity()
    {
        Settings.Instance.mouseSensitivity = float.Parse(sensitivityInputField.text);
        Settings.Instance.SaveSensitivity();
    }
    #endregion

    #region ChangeSfxVolume
    public void ChangeSfxVolume(float sfxVolume)
    {
        Settings.Instance.sfxVolume = sfxVolume;
        Settings.Instance.SaveSfxVolume();
    }
    #endregion
}
