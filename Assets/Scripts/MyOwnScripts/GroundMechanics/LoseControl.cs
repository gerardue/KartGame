using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems; 

namespace Gerardo.GroundMechanics
{
    public class LoseControl : MonoBehaviour
    {
        [Header("Settings")]
        public float forceLose;
        public float expulsionForce;
        public float durationLoseControl; 

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                ArcadeKart kart = other.GetComponentInParent<ArcadeKart>();
                Rigidbody rb = other.GetComponentInParent<Rigidbody>();
                rb.AddForce( kart.fowardDir * expulsionForce, ForceMode.VelocityChange);
                StartCoroutine(C_LoseControl(kart.gameObject.transform)); 
            }
        }

        IEnumerator C_LoseControl(Transform trans)
        {
            yield return new WaitForSeconds(0.5f); 
            float time = 0; 
            while(time < durationLoseControl)
            {
                trans.Rotate(new Vector3(0, forceLose, 0)); 
                time += Time.deltaTime; 
                yield return null; 
            }
        }
    }
}
