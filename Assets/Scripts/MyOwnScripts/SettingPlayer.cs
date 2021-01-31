using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gerardo.EditKart; 

namespace Gerardo.Player
{
    public class SettingPlayer : MonoBehaviour
    {
        public GameObject[] karts;

        private void Start()
        {
            SetPlayer(); 
        }

        void SetPlayer()
        {
            karts[DataGame.Instance.indexKart].SetActive(true); 
            CustomizeKart customizeKart = karts[DataGame.Instance.indexKart].GetComponent<CustomizeKart>();
            customizeKart.ChangeChasisKart(DataGame.Instance.indexChasis);
            customizeKart.ChangeTires(DataGame.Instance.indexTires); 
        }
    }
}