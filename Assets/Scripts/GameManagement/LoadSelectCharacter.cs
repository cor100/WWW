using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Cinemachine;
using TMPro;
using UnityEngine;

public class LoadSelectCharacter : MonoBehaviour
{
    public GameObject[] charPrefabs;
    public Transform startPoint;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    private string[] prefabNames = {"Owl", "Blue", "Pink"};
    // Start is called before the first frame update
    void Start()
    {
        // Load selected character (from the start) based on PlayerPrefs
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        print(selectedCharacter);
        GameObject prefab = charPrefabs[selectedCharacter];
        GameObject clone = Instantiate(prefab, startPoint.position, Quaternion.identity);
        // assign camera to follow player
        cinemachineVirtualCamera.Follow = clone.transform;
    }

}
