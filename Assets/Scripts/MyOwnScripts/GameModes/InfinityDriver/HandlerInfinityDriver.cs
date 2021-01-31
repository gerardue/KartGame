using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro; 
using Gerardo.Game; 

namespace Gerardo.GameModes
{
    public class HandlerInfinityDriver : MonoBehaviour
    {
        public static HandlerInfinityDriver Instance;

        public delegate void CrashedPlayer();
        public static event CrashedPlayer OnCrashedPlayer; 

        [Header("GameFlow")]
        public GameFlow gameFlow; 

        [Header("Features Tracks")]
        public float speedTrack;

        [Header("Features Karts Enemies")]
        public float speedKarts;

        [Header("Time to Spawn new karts enemies")]
        public float minTimeSpawn;
        public float maxTimeSpawn; 

        [Header("Initial Positioin Karts")]
        public Transform initialPositioinKarts;

        [Header("Counter Meters")]
        public TextMeshProUGUI counterMeters;
        public float currentMeters;

        [Header("Increase speed every second according to the variable")]
        [Tooltip("This variable increase speed of karts and track")]
        public float secondsToIncreaseSpeed; 
        public bool isVariableSpeed; 

        [Header("Pool karts Enemies")]
        public List<GameObject> kartsEnemies = new List<GameObject>();

        [Header("Last Track")]
        public MovementTrack lastTrack; 

        [HideInInspector]
        public List<GameObject> kartsEnemiesOnUse = new List<GameObject>();

        [HideInInspector]
        public float[] positionsKart = {-3f, 0f, 3f};

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else if (Instance != null && Instance == this) Destroy(gameObject);
            Time.timeScale = 1; 
        }

        private void Update()
        {
            currentMeters += Time.deltaTime;
            counterMeters.text = currentMeters.ToString("F0") + "m"; 
        }

        private void Start()
        {
            StartCoroutine(CCreatorKartsController()); 
            StartCoroutine(CCounterMeters()); 
        }

        IEnumerator CCreatorKartsController()
        {
            while (!gameFlow.isGameOver)
            {
                int randomKart = Random.Range(0, kartsEnemies.Count);
                kartsEnemies[randomKart].SetActive(true);
                kartsEnemiesOnUse.Add(kartsEnemies[randomKart]);
                kartsEnemies.Remove(kartsEnemies[randomKart]);
                float randomTime = Random.Range(minTimeSpawn, maxTimeSpawn);
                yield return new WaitForSeconds(randomTime);
            }
        }

        IEnumerator CCounterMeters()
        {
            yield return new WaitForSeconds(secondsToIncreaseSpeed);
            while (!gameFlow.isGameOver && isVariableSpeed)
            {
                speedKarts += 1;
                speedTrack += 1; 
                yield return new WaitForSeconds(secondsToIncreaseSpeed); 
            }
        }

        public float RandomPositionKart()
        {
            int posX = Random.Range(0, positionsKart.Length);
            return positionsKart[posX]; 
        }

        public void PlayerHasBeenCrashed()
        {
            if (OnCrashedPlayer != null)
                OnCrashedPlayer(); 
        }
    }
}
