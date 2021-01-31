using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gerardo.EditKart
{
    public class SelectedKartController : MonoBehaviour
    {
        [Header("Change Tires Buttons")]
        public Button tires1;
        public Button tires2;
        public Button tires3;
        public Button tires4;

        [Header("Change Color Chasis Buttons")]
        public Button chasis1;
        public Button chasis2;
        public Button chasis3;
        public Button chasis4;

        [Header("Select Kart Buttons")]
        public GameObject woodTruck; 
        public GameObject sharkMonster; 
        public GameObject monsterTruck;

        private void Start()
        {
            EnableWoodTruck(); 
        }

        public void EnableWoodTruck()
        {
            ActivateEspecificKart(woodTruck); 
            CustomizeKart customizeKart = woodTruck.GetComponent<CustomizeKart>();
            AddlistenersToButtons(customizeKart);
            DataGame.Instance.indexKart = 0; 
        }

        public void EnableSharkMonster()
        {
            ActivateEspecificKart(sharkMonster);
            CustomizeKart customizeKart = sharkMonster.GetComponent<CustomizeKart>();
            AddlistenersToButtons(customizeKart);
            DataGame.Instance.indexKart = 1;
        }

        public void EnableMonsterTruck()
        {
            ActivateEspecificKart(monsterTruck);
            CustomizeKart customizeKart = monsterTruck.GetComponent<CustomizeKart>();
            AddlistenersToButtons(customizeKart);
            DataGame.Instance.indexKart = 2;
        }

        void ActivateEspecificKart(GameObject kart)
        {
            woodTruck.SetActive(false);
            sharkMonster.SetActive(false);
            monsterTruck.SetActive(false);
            kart.SetActive(true); 
        }

        void AddlistenersToButtons(CustomizeKart pCustomizeKart)
        {
            CleanListenersButtons();
            tires1.onClick.AddListener(() => pCustomizeKart.ChangeTires(0)); 
            tires2.onClick.AddListener(() => pCustomizeKart.ChangeTires(1)); 
            tires3.onClick.AddListener(() => pCustomizeKart.ChangeTires(2)); 
            tires4.onClick.AddListener(() => pCustomizeKart.ChangeTires(3)); 
            chasis1.onClick.AddListener(() => pCustomizeKart.ChangeChasisKart(0));
            chasis2.onClick.AddListener(() => pCustomizeKart.ChangeChasisKart(1));
            chasis3.onClick.AddListener(() => pCustomizeKart.ChangeChasisKart(2));
            chasis4.onClick.AddListener(() => pCustomizeKart.ChangeChasisKart(3));
        }

        void CleanListenersButtons()
        {
            tires1.onClick.RemoveAllListeners(); 
            tires2.onClick.RemoveAllListeners(); 
            tires3.onClick.RemoveAllListeners(); 
            tires4.onClick.RemoveAllListeners(); 
            chasis1.onClick.RemoveAllListeners(); 
            chasis2.onClick.RemoveAllListeners(); 
            chasis3.onClick.RemoveAllListeners(); 
            chasis4.onClick.RemoveAllListeners(); 
        }
    }
}