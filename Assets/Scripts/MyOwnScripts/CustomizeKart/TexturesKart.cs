using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gerardo.EditKart
{
    public class TexturesKart : MonoBehaviour
    {
        public static TexturesKart Instance; 

        public Texture[] texturesTires; 
        public Texture[] normalMapsTires;
        public Texture[] texturesChasis; 

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else if (Instance != null && Instance == this) Destroy(gameObject); 
        }
    }
}