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


        // Timer to stop fallParticle after 1 second.
        if (isFallParticlePlaying)
        {
            fallParticleTimer += Time.deltaTime;

            // Stop fallParticle after 1 second has passed.
            if (fallParticleTimer >= 1.0f) // Corrected to check for 1 second
            {
                fallParticle.Stop();
                isFallParticlePlaying = false;
            }
        }

        // Check if the character is not grounded to possibly play the fallParticle.
        if (groundChecker.returnGroundedState())
        {
            if (!isFallParticlePlaying) 
            {
                fallParticle.Play();
                isFallParticlePlaying = true;
                fallParticleTimer = 0; // Reset the timer to count 1 second from now.
            }
        }
        else // If the character is grounded...
        {
            if (isFallParticlePlaying) // And if fallParticle was playing, stop it.
            {
                fallParticle.Stop();
                isFallParticlePlaying = false;
            }
        }

   
      

    }
}
