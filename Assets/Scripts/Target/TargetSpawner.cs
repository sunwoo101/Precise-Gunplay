using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is used to spawn targets
 */
public class TargetSpawner : MonoBehaviour
{
    #region Variables
    [SerializeField] int initialTargetCount;
    [Header("References")]
    [SerializeField] GameObject target;
    [SerializeField] TargetBounds targetBounds;
    #endregion

    #region Start
    private void Start()
    {
        // Spawns initialTargetCount amount of targets at the start
        for (int i = 0; i < initialTargetCount; i++)
        {
            Spawn();
        }
    }
    #endregion

    #region Spawn
    public void Spawn()
    {
        // Spawns a target with a randomly generated position using the TargetBounds script
        Instantiate(target, targetBounds.GetRandomPosition(), Quaternion.identity);
    }
    #endregion
}
