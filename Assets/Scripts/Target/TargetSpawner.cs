using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is used to spawn targets
 */
public class TargetSpawner : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject target;
    [SerializeField] int initialTargetCount;
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
        Instantiate(target, TargetBounds.TargetBoundsInstance.GetRandomPosition(), Quaternion.identity);
    }
    #endregion
}
