using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    #region Variables
    [Header("References")]
    [SerializeField] InputField sensitivityInputField;
    #endregion

    #region Start
    private void Start()
    {
        sensitivityInputField.text = Settings.mouseSensitivity.ToString();
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
        Settings.mouseSensitivity = float.Parse(sensitivityInputField.text);
        Settings.SettingsInstance.SaveSensitivity();
    }
    #endregion
}