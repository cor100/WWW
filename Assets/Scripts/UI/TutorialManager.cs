using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{

    [SerializeField] private float tutorialDestroyTime;
    private bool firstTutorialDestroyed = false;

    // Update is called once per frame
    void Update()
    {
        if (!firstTutorialDestroyed)
        {
            firstTutorialDestroy();
        }
    }

    private void firstTutorialDestroy()
    {
        try
        {
            if (CharHorizontalMovement.Get().returnHasMovedAlready())
            {
                StartCoroutine(IDisableTutorialScreen());
                firstTutorialDestroyed = true;
            }
        }
        catch
        {

        }
    }

    private IEnumerator IDisableTutorialScreen()
    {
        yield return new WaitForSeconds(tutorialDestroyTime);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(tutorialDestroyTime);
    }
}
