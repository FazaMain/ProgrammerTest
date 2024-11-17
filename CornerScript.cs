using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CornerScript : MonoBehaviour
{
    public bool Right;
    public static event Action<bool> Corner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Corner?.Invoke(Right);
            this.gameObject.SetActive(false);
        }
    }

}
