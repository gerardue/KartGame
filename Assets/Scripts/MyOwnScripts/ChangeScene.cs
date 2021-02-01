using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ChangeScene : MonoBehaviour
{
    public void LoadSceneInMainMenu(string nameScene)
    {
        SceneManager.LoadScene("SelectKart");
        DataGame.Instance.nameSceneToLoad = nameScene; 
    }

    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene); 
    }
}
