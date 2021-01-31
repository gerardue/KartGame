using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataGame : MonoBehaviour
{
    public static DataGame Instance;

    [Header("Data Game")]
    public int indexKart; 
    public int indexTires; 
    public int indexChasis;
    public string nameSceneToLoad; 

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject); 
    }

    
}
