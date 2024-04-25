using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Barrier : MonoBehaviour
{
    private float restartTime = .3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            Invoke("ReloadScene", restartTime);
        }
    }

    public void ReloadScene()
    {
        PointStats.ResetPointsCollected();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}