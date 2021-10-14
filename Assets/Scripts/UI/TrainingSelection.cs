using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrainingSelection : MonoBehaviour
{
    #region Variables
    public static int timer;
    string trainingSelection;
    #endregion

    #region SelectTraining
    public void SelectTraining(GameObject selection)
    {
        // Store the button name in a string to use later when loading the scene
        trainingSelection = selection.name;
    }
    #endregion

    #region ChooseTimer
    public void ChooseTimer(GameObject selection)
    {
        // Sets the timer to the number on the button
        timer = int.Parse(selection.name);
        LoadTraining();
    }
    #endregion

    #region LoadTraining
    private void LoadTraining()
    {
        // Loads the training scene
        SceneManager.LoadScene(trainingSelection);
    }
    #endregion
}
