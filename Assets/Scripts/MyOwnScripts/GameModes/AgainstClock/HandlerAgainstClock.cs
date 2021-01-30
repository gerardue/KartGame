using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Gerardo.TimeController;
using Gerardo.Game; 
using Random = UnityEngine.Random; 

namespace Gerardo.GameModes
{
    public class HandlerAgainstClock : MonoBehaviour
    {
        [System.Serializable]
        public struct FeaturesBonusTime
        {
            public float timeToAdd;
            public Color color;
            public int amount; 
        }

        [Header("Timer")]
        public TextMeshProUGUI timer; 

        [Header("Total Time")]
        public float time;

        [Header("AmountLaps")]
        public int amountLaps;

        [Header("Features for Bonus of Time")]
        [Tooltip("The sum of each \"amount\" property must be equal to the amount of \"time bonus\" objects in the scene ")]
        public List<FeaturesBonusTime> typesBonusesOfTime = new List<FeaturesBonusTime>();

        [Header("GameFlow Manager")]
        public GameFlow gameFlow; 

        List<GameObject> bonusesOfTime = new List<GameObject>();

        private void Start()
        {
            AssignBonusesOfTime();
            HandlerTime.OnSetTimeInitial(time);   
        }

        private void Update()
        {
            if((!gameFlow.isGameOver && !gameFlow.isWin) && GameFlow.raceStarted)
                HandlerTime.Timer(timer);
        }

        void AssignBonusesOfTime()
        {
            FindBonusesOfTime();
            
            for(int i = 0; i < typesBonusesOfTime.Count; i ++)
            {
                for(int count = 0; count < typesBonusesOfTime[i].amount; count++)
                {
                    if (bonusesOfTime.Count != 0)
                    {
                        int random = Random.Range(0, bonusesOfTime.Count);
                        BonusOfTime _bonus = bonusesOfTime[random].GetComponent<BonusOfTime>();
                        _bonus.timeToAdd = typesBonusesOfTime[i].timeToAdd;
                        _bonus.ChangeColor(typesBonusesOfTime[i].color);
                        bonusesOfTime.RemoveAt(random);
                    }
                    else return; 
                }
            }
        }

        void FindBonusesOfTime()
        {
            GameObject[] bonuses = GameObject.FindGameObjectsWithTag("BonusTime");
            bonusesOfTime.AddRange(bonuses); 
        }

        //void GameOver()
        //{
        //    gameFlow.GameOver();
        //}

        //private void OnEnable()
        //{
        //    HandlerTime.onTimerFinished += GameOver; 
        //}

        //private void OnDisable()
        //{
        //    HandlerTime.onTimerFinished -= GameOver;
        //}
    }
}
