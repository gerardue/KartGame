using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;
using TMPro;
using UnityEngine.SceneManagement;
using Gerardo.TimeController;

namespace Gerardo.Game
{
    public class GameFlow : MonoBehaviour
    {
        ArcadeKart[] karts;
        public static bool raceStarted;

        [Header("Countdown")]
        public TextMeshProUGUI countdownText;

        [Header("Canvases Win and Lose")]
        public GameObject canvasGameOver;
        public GameObject canvasWin;

        public bool isGameOver;
        public bool isWin;

        private void Start()
        {
            raceStarted = false;
            karts = FindObjectsOfType<ArcadeKart>();
            EnableKart(false); 
            StartCoroutine(CRaceCountdown()); 
        }

        IEnumerator CRaceCountdown()
        {
            int countdown = 4;
            while (countdown > 1)
            {
                countdown--;
                countdownText.text = countdown.ToString(); 
                yield return new WaitForSeconds(1f);
            }

            countdownText.text = "GO";
            countdownText.gameObject.SetActive(false); 
            StartRace(); 
        }

        void StartRace()
        {
            EnableKart(true); 
            raceStarted = true; 
        }

        void EnableKart(bool isEnable)
        {
            foreach (ArcadeKart k in karts)
            {
                k.SetCanMove(isEnable);
            }
        }

        public void GameOver()
        {
            canvasGameOver.SetActive(true);
            EnableKart(false);
            isGameOver = true; 
        }

        public void Win()
        {
            canvasWin.SetActive(true);
            EnableKart(false);
            isWin = true; 
        }

        public void PlayAgain()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene("Main");
        }

        private void OnEnable()
        {
            HandlerTime.onTimerFinished += GameOver;
        }

        private void OnDisable()
        {
            HandlerTime.onTimerFinished -= GameOver;
        }
    }
}
