using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    private int pointsCollected = 0;

    public void UpdatePointsCollected()
    {
        pointsCollected += 1;
    }

    public void ResetPointsCollected()
    {
        pointsCollected = 0;
    }
}
