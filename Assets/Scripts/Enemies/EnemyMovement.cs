using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // positions relative to the original position
    [SerializeField] private List<Vector3> wayPoints;
    private int wayPointsIndex = 0;
    private int wayPointsLength;

    //[SerializeField] private int moveSpeed;
    // When the distance between Enemy Pos & Target Pos is less than arrivalThreshold, consider Enemy Pos to be at Target Pos
    [SerializeField] private float arrivalThreshold;
    [SerializeField] private float waitingSecondsPerPosition;
    [SerializeField] private float moveDistancePerFrame;

    private Vector3 nextTargetPosition;
    private bool arrivedAtNextPos = false;
    private bool isAlive = true;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(wayPoints[0], (float) 0.1);
        Gizmos.DrawSphere(wayPoints[1], (float) 0.1);
    }

    // Start is called before the first frame update
    void Start()
    {
        wayPointsLength = wayPoints.Count - 1;
        GetNextTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(IMovingCoroutine());
        if (arrivedAtNextPos)
        {
            Debug.Log("arrived from update");
        }
    }

    // method movingCoroutine
        // if enemy is alive
        // while distance between target position & my position > arrival threshold, move
        // otherwise, wait
        // use vector3.movetowards()
    private IEnumerator IMovingCoroutine()
    {
        if (isAlive)
        {
            if (!arrivedAtNextPos)
            {
                float withinArrivalThreshold = (transform.position - nextTargetPosition).magnitude;
                if (withinArrivalThreshold > arrivalThreshold)
                {
                    transform.position = Vector3.MoveTowards(transform.position, nextTargetPosition, moveDistancePerFrame * Time.deltaTime);
                }
                else
                {
                    yield return new WaitForSeconds(waitingSecondsPerPosition);
                    arrivedAtNextPos = true;
                    Debug.Log("arrived from coroutine");
                }
            }
            else
            {
                GetNextTargetPosition();
                arrivedAtNextPos = false;
            }
        }
    }

    // method getting next target position, loop through the list & return
    private void GetNextTargetPosition()
    {
        Vector3 targetPosition = wayPoints[wayPointsIndex];
        if(wayPointsIndex >= wayPointsLength)
        {
            wayPointsIndex = 0;
        }
        else
        {
            wayPointsIndex += 1;
        }

        nextTargetPosition = targetPosition;
    }

    // on draw gizmo selected
    // for each pos in waypoints, draws a sphere in that position with a certain size
        // gizmos.drawSphere 
}
