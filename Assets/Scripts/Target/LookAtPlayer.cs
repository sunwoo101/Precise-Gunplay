using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script allows the target to look at the player
 */
public class LookAtPlayer : MonoBehaviour
{
    private void Update()
    {
        Quaternion rotationAngle = Quaternion.LookRotation(Vector3.zero - transform.position);
        transform.rotation = Quaternion.Slerp(new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w), new Quaternion(transform.rotation.x, rotationAngle.y, transform.rotation.z, transform.rotation.w), 1);
    }
}
