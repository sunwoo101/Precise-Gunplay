using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This scipt is used for mouse movement
 */
public class CameraMovement : MonoBehaviour
{
    #region Variables
    float xRotation;
    float mouseSensitivity;
    // References
    [SerializeField] Transform player;
    #endregion

    #region Update
    void Update()
    {
        if (!PauseMenu.paused)
        {
            // Convert to Valorant sens
            mouseSensitivity = Settings.mouseSensitivity *  1.3992f;

            // Mouse input
            float m_pitch = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
            float m_yaw = Input.GetAxisRaw("Mouse X") * mouseSensitivity;

            // Looking up and down
            xRotation -= m_pitch;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localEulerAngles = new Vector3(xRotation, 0f, 0f);

            // Looking left and right
            player.Rotate(Vector3.up * m_yaw);
        }
    }
    #endregion
}
