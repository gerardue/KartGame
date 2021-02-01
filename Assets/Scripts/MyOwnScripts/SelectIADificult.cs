using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gerardo.IA
{
    public class SelectIADificult : MonoBehaviour
    {
        public void EasyIA()
        {
            DataGame.Instance.dificultIA = DificultIA.easy; 
        }

        public void MediumIA()
        {
            DataGame.Instance.dificultIA = DificultIA.medium;
        }

        public void HardIA()
        {
            DataGame.Instance.dificultIA = DificultIA.hard;
        }
    }
}