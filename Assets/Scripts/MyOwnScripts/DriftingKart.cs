using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.KartSystems
{
    public class DriftingKart : MonoBehaviour
    {
        bool drifting;
        public ArcadeKart kart; 

        // Update is called once per frame
        void Update()
        {
            //if (Input.GetButtonDown("Jump") /*&& !drifting*/ && Input.GetAxis("Horizontal") != 0)
            //{
            //    drifting = true;
            //    kart.turn = 3f;
            //    Debug.Log(kart.turn); 
            //}

            //if(Input.GetButtonUp("Jump"))
            //{
            //    drifting = false;
            //    kart.turn = kart.Input.x; 
            //}
        }
    }
}