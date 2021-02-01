using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gerardo.GameModes
{
    public static class ExtendedToolsInfinityDriver
    {
        public static void ResetPositionTrack(this Transform trans)
        {
            trans.position = new Vector3(trans.position.x, trans.position.y, 
                HandlerInfinityDriver.Instance.lastTrack.transform.position.z + 9.9f);
            HandlerInfinityDriver.Instance.lastTrack = trans.gameObject.GetComponent<MovementTrack>(); 
        }

        public static void ResetPositionKart(this Transform trans)
        {
            Transform initialPosition = HandlerInfinityDriver.Instance.initialPositioinKarts;
            trans.position = new Vector3(HandlerInfinityDriver.Instance.RandomPositionKart(), 
                initialPosition.position.y, initialPosition.position.z);
            HandlerInfinityDriver.Instance.kartsEnemies.Add(trans.gameObject);
            HandlerInfinityDriver.Instance.kartsEnemiesOnUse.Remove(trans.gameObject);
            trans.gameObject.SetActive(false); 
        }
    }
}
