using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Gerardo.Game
{
    public class Pause : MonoBehaviour
    {
        public Button firstSelected;
        public GameObject pauseCanvas; 

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(Time.timeScale == 1)
                {
                    pauseCanvas.SetActive(true);
                    firstSelected.Select();
                    Time.timeScale = 0;
                }
                else if(Time.timeScale == 0)
                {
                    pauseCanvas.SetActive(false);
                    Time.timeScale = 1;
                }
            }
        }

        public void PlayAgain()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene("Main");
            Time.timeScale = 1;
        }
    }
}