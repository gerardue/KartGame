using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems; 

namespace Gerardo.IA
{
    public enum DificultIA
    {
        easy = 3, 
        medium = 2, 
        hard = 1
    }

    public class IAKart : MonoBehaviour
    {
        [Header("Features")]
        public float velocity; 
        public DificultIA dificultIA = new DificultIA();
        public List<Transform> wayPoints = new List<Transform>();

        [Header("Type Animations")]
        public iTween.EaseType animMove = new iTween.EaseType(); 
        public iTween.EaseType animSteer = new iTween.EaseType();

        [Header("Player Kart")]
        public ArcadeKart playerKart; 

        bool firstTime = true; 

        private void Start()
        {
            Time.timeScale = 1; 
            dificultIA = DataGame.Instance.dificultIA; 
            wayPoints = WayPointsHandler.Instance.wayPoints;
            SetVelocityIA(); 
            StartCoroutine(ExecuteIA());
        }

        void SetVelocityIA()
        {
            if (dificultIA == DificultIA.easy) { velocity = 8; playerKart.baseStats.TopSpeed = 10; }
            else if (dificultIA == DificultIA.medium) { velocity = 17; playerKart.baseStats.TopSpeed = 20; }
            else if (dificultIA == DificultIA.hard) { velocity = 25; playerKart.baseStats.TopSpeed = 28; }
        }

        IEnumerator ExecuteIA()
        {
            for (int i = 0; i < wayPoints.Count; i += (int)dificultIA)
            {
                if (firstTime) { Move(i); firstTime = false; }
                else if(!firstTime && i < wayPoints.Count) { Move(i); }
                else if(i >= wayPoints.Count) { i = wayPoints.Count - 2; Move(i); }

                yield return new WaitUntil(() => 
                    Vector3.Distance(transform.position, wayPoints[i].position) < 0.005f); 

                if ((i + (int)dificultIA) == wayPoints.Count || (i + (int)dificultIA) >= wayPoints.Count) //Reset
                    i = -1;
            }
        }

        void Move(int index)
        {
            iTween.MoveTo(this.gameObject, iTween.Hash("position", wayPoints[index].position, "speed", velocity, 
                "easeType", animMove));
            iTween.RotateTo(this.gameObject, iTween.Hash("y", wayPoints[index].localEulerAngles.y, 
                "time", .2f, 
                "easeType", animSteer)); 
        }
    }
}