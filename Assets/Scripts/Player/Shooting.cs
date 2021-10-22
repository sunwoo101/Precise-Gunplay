using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is for shooting
 * It also manages the player score stored in the Score script
 */
public class Shooting : MonoBehaviour
{
    #region Variables
    [SerializeField] int headPoints;
    [SerializeField] int bodyPoints;
    [SerializeField] int legsPoints;
    [SerializeField] int missPoints;
    [SerializeField] float sfxVolume;
    [Header("References")]
    [SerializeField] Camera cam;
    [SerializeField] SpawnHandler spawnHandler;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip hitSound;
    #endregion

    #region Start
    private void Start()
    {
        sfxVolume = Settings.Instance.sfxVolume;
    }
    #endregion

    #region Update
    private void Update()
    {
        if (!PauseMenu.paused)
        {
            // If mouse button is clicked
            if (Input.GetMouseButtonDown(0))
            {
                Score.Instance.totalShotCount++;
                // Create a ray
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                // If the ray hits
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Debug.Log(hit.collider.gameObject.tag);
                    // Add score to the Score script and destroy the gameobject
                    if (hit.collider.gameObject.tag == "Head")
                    {
                        Score.Instance.headShotCount++;
                        Score.Instance.score += headPoints;
                        Destroy(hit.transform.parent.gameObject);
                        // Play hit sound
                        audioSource.PlayOneShot(hitSound, sfxVolume);
                        // Spawn another target
                        spawnHandler.Spawn();
                    }
                    else if (hit.collider.gameObject.tag == "Body")
                    {
                        Score.Instance.bodyShotCount++;
                        Score.Instance.score += bodyPoints;
                        Destroy(hit.transform.parent.gameObject);
                        // Play hit sound
                        audioSource.PlayOneShot(hitSound, sfxVolume);
                        // Spawn another target
                        spawnHandler.Spawn();
                    }
                    else if (hit.collider.gameObject.tag == "Legs")
                    {
                        Score.Instance.legShotCount++;
                        Score.Instance.score += legsPoints;
                        Destroy(hit.transform.parent.gameObject);
                        // Play hit sound
                        audioSource.PlayOneShot(hitSound, sfxVolume);
                        // Spawn another target
                        spawnHandler.Spawn();
                    }
                    // Lose score if you don't hit something thats not a target
                    else if (Score.Instance.score >= missPoints)
                    {
                        Score.Instance.missedShotCount++;
                        Score.Instance.score -= missPoints;
                    }
                    else
                    {
                        Score.Instance.missedShotCount++;
                        Score.Instance.score = 0;
                    }
                }
                // Lose score if you miss your shot
                else if (Score.Instance.score >= missPoints)
                {
                    Score.Instance.missedShotCount++;
                    Score.Instance.score -= missPoints;
                }
                else
                {
                    Score.Instance.missedShotCount++;
                    Score.Instance.score = 0;
                }
            }
        }
    }
    #endregion
}
