using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;
    [SerializeField] ParticleSystem fallParticle;

    [Range(0,10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0,0.2F)]
    [SerializeField] float dustFormationPeriod;

    [SerializeField] Rigidbody2D playerRb;

    float counter;
    public GameObject playerObject;
    private CharGroundChecker groundChecker;

    private float fallParticleTimer = 0; 
    private bool isFallParticlePlaying = false; 


    // Start is called before the first frame update
    void Start()
    {
        groundChecker = playerObject.GetComponent<CharGroundChecker>();
    }

    // Update is called once per frame
    private void Update()
    {
        counter += Time.deltaTime;

        if ((Mathf.Abs(playerRb.velocity.x) > occurAfterVelocity) && groundChecker.returnGroundedState())
        {
            movementParticle.Play();
            counter = 0;
        }

        //if (!groundChecker.returnGroundedState())
        //{
        //    fallParticle.Play();
        //}

        //if (!groundChecker.returnGroundedState())
        //{
        //    if (!isFallParticlePlaying) // Start fallParticle if not already started.
        //    {
        //        fallParticle.Play();
        //        isFallParticlePlaying = true;
        //        fallParticleTimer = 0; // Reset timer.
        //    }
        //}
        //else
        //{
        //    if (isFallParticlePlaying)
        //    {
        //        fallParticle.Stop(); // Stop fallParticle if player is grounded.
        //        isFallParticlePlaying = false;
        //    }
        //}

        //// Timer to stop fallParticle after 1 second.
        //if (isFallParticlePlaying)
        //{
        //    fallParticleTimer += Time.deltaTime;
        //    if (fallParticleTimer >= 0.1f) // Check if 1 second has passed.
        //    {
        //        fallParticle.Stop();
        //        isFallParticlePlaying = false;
        //    }
        //}
 
    }
}
