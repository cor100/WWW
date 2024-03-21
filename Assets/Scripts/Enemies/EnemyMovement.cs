using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform enemyTransform;

    // positions relative to the original position
    [SerializeField] private List<Vector2> wayPoints;
    private int wayPointsIndex = 0;
    private int wayPointsLength;

    [SerializeField] private int moveSpeed;
    // When the distance between Enemy Pos & Target Pos is less than arrivalThreshold, consider Enemy Pos to be at Target Pos
    [SerializeField] private float arrivalThreshold;
    [SerializeField] private float waitingSecondsPerPosition;

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.DrawSphere();
    //}

    // Start is called before the first frame update
    void Start()
    {
        wayPointsLength = wayPoints.Count;
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Transform>().position = 
    }

    // method movingCoroutine
        // if enemy is alive
        // while distance between target position & my position > arrival threshold, move
        // otherwise, wait
        // use vector3.movetowards()

    // method getting next target position, loop through the list & return
    Vector2 GetNextTargetPosition()
    {
        Vector2 targetPosition = wayPoints[wayPointsIndex];
        if(wayPointsIndex >= wayPointsLength)
        {
            wayPointsIndex = 0;
        }
        else
        {
            wayPointsIndex += 1;
        }

        return targetPosition;
    }

    // on draw gizmo selected
    // for each pos in waypoints, draws a sphere in that position with a certain size
        // gizmos.drawSphere 
}
