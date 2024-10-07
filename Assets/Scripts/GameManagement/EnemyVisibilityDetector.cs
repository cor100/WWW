using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisibilityDetector : MonoBehaviour
{

    [SerializeField] private List<GameObject> enemies;
    private Dictionary<GameObject, bool> enemiesDict;
    //private List<bool> enemiesSoundsPlaying;
    private Camera mainCamera;

    // responsibility of class: detect when enemies are on screen so as to play their audio when they are

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        enemiesDict = new Dictionary<GameObject, bool>();

        for (int i = 0; i < enemies.Count; i++)
        {
            enemiesDict.Add(enemies[i], false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i])
            {
                enemiesDict.Remove(enemies[i]);
                break;
            }

            Vector3 screenPoint = mainCamera.WorldToScreenPoint(enemies[i].transform.position);
            bool isOnScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < Screen.width && screenPoint.y > 0 && screenPoint.y < Screen.height;

            if (isOnScreen && !enemiesDict[enemies[i]])
            {
                enemies[i].GetComponent<AudioSource>().Play();
                enemiesDict[enemies[i]] = true;
            }
            else if(!isOnScreen && enemiesDict[enemies[i]])
            {
                enemies[i].GetComponent<AudioSource>().Stop();
                enemiesDict[enemies[i]] = false;
            }
        }
    }
}
