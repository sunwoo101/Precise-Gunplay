using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script stores player settings into player prefs.
 * The variables are static so they can be accessed from other scripts
 */
public class Settings : MonoBehaviour
{
    #region Variables
    public static Settings Instance;
    [Header("Dont touch")]
    public float mouseSensitivity;
    #endregion

    #region Awake
    private void Awake()
    {
        Instance = this;
        // Load shit from PlayerPrefs
        mouseSensitivity = PlayerPrefs.GetFloat("mouseSensitivity", 1);
    }
    #endregion

    #region SaveSensitivity
    public void SaveSensitivity()
    {
        PlayerPrefs.SetFloat("mouseSensitivity", mouseSensitivity);
    }
    #endregion
}
