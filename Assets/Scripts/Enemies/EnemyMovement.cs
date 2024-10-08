using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // positions relative to the original position
    [SerializeField] private List<Vector3> wayPoints;
    private int wayPointsIndex = 0;
    private int wayPointsLength;

    // When the distance between Enemy Pos & Target Pos is less than arrivalThreshold,
    // consider Enemy Pos to be at Target Pos
    [SerializeField] private float arrivalThreshold;
    [SerializeField] private float waitingSecondsPerPosition;
    [SerializeField] private float moveDistancePerFrame;
    [SerializeField] private bool startByMovingRight;

    private Vector3 nextTargetPosition;
    private bool arrivedAtNextPos = false;
    private bool isAlive = true;
    private SpriteRenderer enemySpriteRenderer;

    // to visualize the positions enemies will go to
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
        StartCoroutine(IMovingCoroutine());
        enemySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        enemySpriteRenderer.flipX = !startByMovingRight;
    }


    // enemy moving to and from specified positions
    private IEnumerator IMovingCoroutine()
    {
        while (isAlive)
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
                }
            }
            else
            {
                GetNextTargetPosition();
                arrivedAtNextPos = false;
                enemySpriteRenderer.flipX = !enemySpriteRenderer.flipX;
            }
            yield return null;
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
}
