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
    [SerializeField] Camera cam;
    [SerializeField] SpawnHandler spawnHandler;
    #endregion

    #region Update
    private void Update()
    {
        if (!PauseMenu.paused)
        {
            // If mouse button is clicked
            if (Input.GetMouseButtonDown(0))
            {
                Score.totalShotCount++;
                // Create a ray
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                // If the ray hits
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    // Add score to the Score script and destroy the gameobject
                    if (hit.collider.gameObject.tag == "Head")
                    {
                        Score.headShotCount++;
                        Score.score += 100;
                        Destroy(hit.transform.parent.gameObject);
                    }
                    else if (hit.collider.gameObject.tag == "Body")
                    {
                        Score.bodyShotCount++;
                        Score.score += 25;
                        Destroy(hit.transform.parent.gameObject);
                    }
                    else if (hit.collider.gameObject.tag == "Legs")
                    {
                        Score.legShotCount++;
                        Score.score += 15;
                        Destroy(hit.transform.parent.gameObject);
                    }
                    // Lose score if you don't hit something thats not a target
                    else if (Score.score >= 10)
                    {
                        Score.missedShotCount++;
                        Score.score -= 10;
                    }
                    else
                    {
                        Score.missedShotCount++;
                        Score.score = 0;
                    }
                    // Spawn another target
                    spawnHandler.Spawn();
                }
                // Lose score if you miss your shot
                else if (Score.score >= 10)
                {
                    Score.missedShotCount++;
                    Score.score -= 10;
                }
                else
                {
                    Score.missedShotCount++;
                    Score.score = 0;
                }
            }
        }
    }
    #endregion
}
