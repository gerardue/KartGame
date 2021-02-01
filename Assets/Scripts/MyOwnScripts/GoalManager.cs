using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using Gerardo.GameModes; 

namespace Gerardo.Game
{
    public class GoalManager : MonoBehaviour
    {
        public static GoalManager Instance; 

        [Header("GameFlow")]
        public GameFlow gameFlow;
        public HandlerAgainstClock againstClock;

        [Header("Laps UI")]
        public TextMeshProUGUI laps; 

        RaceCheck[] raceChecks; 

        int lapsDone = -1;
        int raceChecksObteined = 0; 
        public int ChecksObteined { get { return raceChecksObteined; } set { raceChecksObteined = value; } }

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else if (Instance != null && Instance == this) Destroy(gameObject);
            
            raceChecks = FindObjectsOfType<RaceCheck>();
            laps.text = "0/" + againstClock.amountLaps; 
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                lapsDone++;
                laps.text = lapsDone + "/" + againstClock.amountLaps; 
                if(lapsDone == againstClock.amountLaps && raceChecksObteined == raceChecks.Length && !gameFlow.isGameOver)
                    gameFlow.Win(); 

                if(lapsDone < againstClock.amountLaps)
                    RestoreRaceChecksAfterSomeLap(); 
            }
        }

        void RestoreRaceChecksAfterSomeLap()
        {
            foreach (RaceCheck item in raceChecks)
            {
                item.gameObject.SetActive(true);
            }
            raceChecksObteined = 0;
        }
    }
}
