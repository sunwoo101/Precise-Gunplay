using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is used to get a random position in a boundary
 */

[RequireComponent(typeof(BoxCollider))]

public class TargetBounds : MonoBehaviour
{
    #region Variables
    [SerializeField] BoxCollider col;
    #endregion

    #region GetRandomPosition
    public Vector3 GetRandomPosition()
    {
        Vector3 center = col.center + transform.position;
        float minX = center.x - col.size.x / 2f;
        float maxX = center.x + col.size.x / 2f;

        float minY = center.y - col.size.y / 2f;
        float maxY = center.y + col.size.y / 2f;

        float minZ = center.z - col.size.z / 2f;
        float maxZ = center.z + col.size.z / 2f;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);

        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

        return randomPosition;
    }
    #endregion
}
