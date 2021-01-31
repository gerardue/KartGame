using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;
using TMPro;
using UnityEngine.SceneManagement;
using Gerardo.TimeController;
using Gerardo.GameModes; 

namespace Gerardo.Game
{
    public enum ModeGame
    {
        againstClock, 
        infinityDriver, 
        race
    }

    public class GameFlow : MonoBehaviour
    {
        ArcadeKart[] karts;
        public static bool raceStarted;

        [Header("Countdown")]
        public TextMeshProUGUI countdownText;

        [Header("Canvases Win and Lose")]
        public GameObject canvasGameOver;
        public GameObject canvasWin;

        [Header("Mode Game")]
        public ModeGame modeGame = new ModeGame(); 

        public bool isGameOver;
        public bool isWin;

        private void Start()
        {
            raceStarted = false;
            karts = FindObjectsOfType<ArcadeKart>();
            EnableKart(false);
            if (modeGame == ModeGame.againstClock)
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
            if (modeGame == ModeGame.infinityDriver)
                Time.timeScale = 0; 
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
            Time.timeScale = 1; 
        }

        private void OnEnable()
        {
            if (modeGame == ModeGame.againstClock)
                HandlerTime.onTimerFinished += GameOver;
            else if (modeGame == ModeGame.infinityDriver)
                HandlerInfinityDriver.OnCrashedPlayer += GameOver; 
        }

        private void OnDisable()
        {
            if (modeGame == ModeGame.againstClock)
                HandlerTime.onTimerFinished -= GameOver;
            else if (modeGame == ModeGame.infinityDriver)
                HandlerInfinityDriver.OnCrashedPlayer -= GameOver;
        }
    }
}
