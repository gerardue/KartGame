using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gerardo.IA
{
    public class WayPoint : MonoBehaviour
    {
        public float radius = 1.0f;
        public WayPoint nextPoint;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, radius);
            if (nextPoint != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, nextPoint.transform.position);
            }
        }
    }
}