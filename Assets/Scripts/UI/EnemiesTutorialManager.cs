using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesTutorialManager : MonoBehaviour
{
    public GameObject menu;

    // Activates menu when the player hits the sign on enemy section
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            menu.SetActive(true);
        }
    }

    // Deactivates menu when the player leaves the enemy section
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            menu.SetActive(false);
        }
    }
}
