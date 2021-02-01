using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gerardo.IA; 

public class DataGame : MonoBehaviour
{
    public static DataGame Instance;

    [Header("Data Game")]
    public int indexKart; 
    public int indexTires; 
    public int indexChasis;
    public string nameSceneToLoad;
    public DificultIA dificultIA; 

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject); 
    }
    
}
