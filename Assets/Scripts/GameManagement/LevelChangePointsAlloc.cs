using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangePointsAlloc : MonoBehaviour
{
    [SerializeField] private List<string> scenes;

    public GameObject pointsRemaining;
    private PointsAllocation pointsAllocation;

    public GameObject hpAlloc;
    private HPAllocation hpAllocation;

    public GameObject strAlloc;
    private STRAllocation strAllocation;

    public GameObject error;

    //public GameObject statsAllocation;
    //private CharStats charStats;


    // Start is called before the first frame update
    void Start()
    {
        error.SetActive(false);
        pointsAllocation = pointsRemaining.GetComponent<PointsAllocation>();
        hpAllocation = hpAlloc.GetComponent<HPAllocation>();
        strAllocation = strAlloc.GetComponent<STRAllocation>();
        //charStats = statsAllocation.GetComponent<CharStats>();
    }

    // Update is called once per frame
    void Update()
    {

    }  

    public void NextLevel()
    {
        if (PlayerPrefs.GetInt("pointsCollected") >= 0)
        {
            print(PlayerPrefs.GetInt("currentLevel") + " current level");

            PlayerPrefs.SetInt("playerHealth", hpAllocation.ReturnNewMaxHealth());
            PlayerPrefs.SetInt("playerStrength", strAllocation.ReturnNewMaxStrength());
            PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("currentLevel") + 1);
            SceneManager.LoadScene(scenes[PlayerPrefs.GetInt("currentLevel")]);

            //charStats.ResetCharacterHealth();
        }
        else
        {
            error.SetActive(true);
        }
            
    }
}
