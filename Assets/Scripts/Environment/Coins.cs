using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public CharacterAnimator characterAnimator;
    private GameObject target;
    private float moveDistancePerFrame = 3f;

    private PointStats pointStats;
    private bool isCoroutineRunning = false;

    private float collectDelayTime;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player") && !isCoroutineRunning)
        {
            isCoroutineRunning = true;
            StartCoroutine(capturedCoin());
        }
    }

    void Start()
    {
        pointStats = FindObjectOfType<PointStats>();
        StartCoroutine(findPlayer());
        collectDelayTime = 0.02f;
    }

    IEnumerator findPlayer()
    {
        while(!GameObject.FindWithTag("player"))
        {
            yield return null;
        }
        target = GameObject.FindWithTag("player");
    }

    IEnumerator capturedCoin()
    {
        while(collectDelayTime > 0)
        {
            collectDelayTime -= 0.1f * Time.deltaTime;
            yield return null;
        }
        if(collectDelayTime <= 0)
        {
            while(Vector3.Distance(target.transform.position, transform.position) >= 0.01f)
            {
                //print(Vector3.Distance(target.transform.position, transform.position));
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveDistancePerFrame * Time.deltaTime);
                yield return null;
            }
        }
        
        pointStats.UpdatePointsCollected();
        Destroy(gameObject);

    }
}
