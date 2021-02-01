using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

namespace Gerardo.GroundMechanics
{
    public class Boost : MonoBehaviour
    {
        public float boostForce;

        private void OnTriggerStay(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                Rigidbody rb = other.GetComponentInParent<Rigidbody>();
                ArcadeKart kart = other.GetComponentInParent<ArcadeKart>(); 
                rb.AddForce( kart.fowardDir * boostForce, ForceMode.VelocityChange); 
            }
        }
    }
}