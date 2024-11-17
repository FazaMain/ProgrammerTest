using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GateScript : MonoBehaviour
{
    public static event Action<bool, int> GateEnter;
    public int GateValue;
    public bool Plus;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GateEnter?.Invoke(Plus, GateValue);
        }
    }


    
}
