using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gerardo.Player
{
    public class MovementKartPlayer : MonoBehaviour
    {
        float posX = 0; 

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                GoToLeft(); 
                
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                GoToRight(); 
            }
        }

        void GoToLeft()
        {
            MoveKart(-3.5f); 
        }

        void GoToRight()
        {
            MoveKart(3.5f); 
        }

        void MoveKart(float unitsToMove)
        {
            posX += unitsToMove;
            if (posX < unitsToMove && posX != 0) posX = unitsToMove;
            else if (posX > unitsToMove && posX != 0) posX = unitsToMove; 
            transform.position = new Vector3(posX, transform.position.y, transform.position.z);
        }
    }
}