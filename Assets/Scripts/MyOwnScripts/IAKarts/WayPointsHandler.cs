using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gerardo.IA
{
    public class WayPointsHandler : MonoBehaviour
    {
        public static WayPointsHandler Instance;

        private int amount = 0;
        public List <Transform> wayPoints = new List<Transform>();

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else if (Instance != null && Instance == this) Destroy(gameObject); 

            amount = transform.childCount;
            
            for (int i = 0; i < amount; i++)
            {
                wayPoints.Add(transform.GetChild(i)); 
                transform.GetChild(i).GetComponent<WayPoint>().nextPoint = i + 1 < amount ?
                    transform.GetChild(i + 1).GetComponent<WayPoint>() :
                    transform.GetChild(0).GetComponent<WayPoint>();
            }
        }
    }
}