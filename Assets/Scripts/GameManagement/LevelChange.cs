using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    [SerializeField] private string nextSceneName;

    // Will be an onTrigger collision
    private void OnTriggerEnter2D(Collider2D doorCollision)
    {
        // If the door is activated by the player going in, switch scenes.
        if (doorCollision.CompareTag("player"))
        {
            PlayerPrefs.SetInt("pointsCollected", PointStats.GetPointsCollected());
            SceneManager.LoadScene("AllocatePoints", LoadSceneMode.Single);
        }
    }

}
