using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;

public class LoadSelectCharacter : MonoBehaviour
{
    public GameObject[] charPrefabs;
    public Transform startPoint;
    private String[] prefabNames = {"Owl", "Blue", "Pink"};
    // Start is called before the first frame update
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        print(selectedCharacter);
        GameObject prefab = charPrefabs[selectedCharacter];
        GameObject clone = Instantiate(prefab, startPoint.position, Quaternion.identity);
        print(selectedCharacter);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
