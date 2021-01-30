using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gerardo.Game
{
    public class RaceCheck : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                GoalManager.Instance.ChecksObteined++;
                gameObject.SetActive(false); 
            }
        }
    }
}