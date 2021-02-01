using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

namespace Gerardo.UINavigation
{
    public class SelectKartUINavigation : MonoBehaviour
    {
        public GameObject[] menus; 

        public void ShowMenu(GameObject menuToShow)
        {
            DesactivateAllMenus(); 
            menuToShow.SetActive(true); 
        }

        public void ReadyToPlay()
        {
            SceneManager.LoadScene(DataGame.Instance.nameSceneToLoad); 
        }

        void DesactivateAllMenus()
        {
            foreach (GameObject menu in menus)
                menu.SetActive(false); 
        }
    }
}