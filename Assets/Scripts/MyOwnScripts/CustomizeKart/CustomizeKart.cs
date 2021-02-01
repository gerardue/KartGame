using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gerardo.EditKart
{
    public class CustomizeKart : MonoBehaviour
    {
        public MeshRenderer[] materialTires;
        public MeshRenderer materialKart;

        public void ChangeTires(int typeTires)
        {
            foreach(MeshRenderer tires in materialTires)
            {
                tires.material.SetTexture("_MainTex", TexturesKart.Instance.texturesTires[typeTires]);
                tires.material.SetTexture("_BumpMap", TexturesKart.Instance.normalMapsTires[typeTires]); 
            }
            DataGame.Instance.indexTires = typeTires; 
        }

        public void ChangeChasisKart(int typeChasis)
        {
            materialKart.material.SetTexture("_MainTex", TexturesKart.Instance.texturesChasis[typeChasis]);
            DataGame.Instance.indexChasis = typeChasis; 
        }
    }
}