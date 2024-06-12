using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointStats : MonoBehaviour
{
    private static int pointsCollected = 0;
    private static int initialPoints;

    void Start()
    {
        initialPoints = PlayerPrefs.GetInt("pointsCollected");
        pointsCollected = initialPoints;
    }

    public void UpdatePointsCollected()
    {
        pointsCollected += 1;
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


}
