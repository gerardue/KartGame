using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gerardo.GameModes;

namespace Gerardo.GameModes
{
    public class MovementTrack : MonoBehaviour
    {
        void Update()
        {
            transform.Translate(new Vector3(0, 0, -1) * HandlerInfinityDriver.Instance.speedTrack * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (transform.position.z <= -8.8f)
                transform.ResetPositionTrack();
        }
    }
}
