using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gerardo.TimeController; 

public class BonusOfTime : MonoBehaviour
{
    public float timeToAdd;
    public Color color; 

    public void ChangeColor(Color color)
    {
        GetComponent<MeshRenderer>().material.color = color; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            HandlerTime.OnSetTime(timeToAdd);
            Destroy(gameObject);  
        }
    }
}
