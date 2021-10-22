using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is used to call a random TargetSpawner.
 * If there is only 1 TargetSpawner in the array then it will call that
 */
public class SpawnHandler : MonoBehaviour
{
    #region Variables
    TargetSpawner targetSpawner;
    [Header("References")]
    [SerializeField] TargetSpawner[] targetSpawners;
    #endregion

    #region Spawn
    public void Spawn()
    {
        // Chooses a random TargetSpawner
        targetSpawner = targetSpawners[Random.Range(0, targetSpawners.Length)];
        // Calls the Spawn function in the TargetSpawner
        targetSpawner.Spawn();
    }
    #endregion
}
