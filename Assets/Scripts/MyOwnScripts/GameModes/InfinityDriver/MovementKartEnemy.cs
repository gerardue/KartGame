using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gerardo.GameModes; 

namespace Gerardo.GameModes
{
    public class MovementKartEnemy : MonoBehaviour
    {
        private void Start()
        {
            transform.ResetPositionKart(); 
        }

        private void Update()
        {
            transform.Translate(new Vector3(0, 0, 1) * HandlerInfinityDriver.Instance.speedKarts * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (transform.position.z <= -9)
                transform.ResetPositionKart(); 
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Player"))
                HandlerInfinityDriver.Instance.PlayerHasBeenCrashed();   
        }
    }
}
