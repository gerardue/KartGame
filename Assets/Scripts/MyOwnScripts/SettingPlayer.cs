using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement; 
using Gerardo.EditKart; 

namespace Gerardo.Player
{
    public class SettingPlayer : MonoBehaviour
    {
        public GameObject[] karts;

        [Header("Use only in the scenes \"MainScene\" and \" RaceAgainstClock\"")]
        public CinemachineVirtualCamera virtualCamera; 

        private void Start()
        {
            SetPlayer();
            SetVirtualCamera(); 
        }

        void SetPlayer()
        {
            karts[DataGame.Instance.indexKart].SetActive(true); 
            CustomizeKart customizeKart = karts[DataGame.Instance.indexKart].GetComponent<CustomizeKart>();
            customizeKart.ChangeChasisKart(DataGame.Instance.indexChasis);
            customizeKart.ChangeTires(DataGame.Instance.indexTires); 
        }

        void SetVirtualCamera()
        {
            if(SceneManager.GetActiveScene().name == "MainScene" || SceneManager.GetActiveScene().name == "RaceAgainstClock")
            {
                virtualCamera.Follow = karts[DataGame.Instance.indexKart].transform;
                virtualCamera.LookAt = karts[DataGame.Instance.indexKart].transform;
            }
        }
    }
}