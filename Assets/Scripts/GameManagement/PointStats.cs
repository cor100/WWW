using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointStats : MonoBehaviour
{
    private static int pointsCollected = 0;
    private static int initialPoints;
    private AudioSource coinAudio;

    void Start()
    {
        initialPoints = PlayerPrefs.GetInt("pointsCollected");
        pointsCollected = initialPoints;
        coinAudio = GetComponent<AudioSource>();
    }

    public void UpdatePointsCollected()
    {
        pointsCollected += 1;
        StartCoroutine(IPlaySound());
    }

    public void UpdatePointsCollected(int points){
        pointsCollected += points;
    }

    public void SubtractPointsCollected()
    {
        pointsCollected -= 1;
    }

    public static void ResetPointsCollected()
    {
        pointsCollected = initialPoints;
    }

    public static int GetPointsCollected()
    {
        return pointsCollected;
    }

    public IEnumerator IPlaySound()
    {
        yield return new WaitForSeconds(0.2f);
        coinAudio.Play();
    }
}
