using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gerardo.GroundMechanics
{
    public class JumpBoost : MonoBehaviour
    {
        public float jumpForce;

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Rigidbody rb = other.GetComponentInParent<Rigidbody>();
                rb.AddForce(new Vector3(0, 1, 0) * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
