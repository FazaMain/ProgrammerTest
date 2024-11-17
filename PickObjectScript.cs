using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickObjectScript : MonoBehaviour
{
    public bool Plus;
    public int Value;
    public static event Action<bool, int> ObjectPickup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(EventTriggerCo());
        }
    }

    IEnumerator EventTriggerCo()
    {
        yield return null;
        ObjectPickup?.Invoke(Plus, Value);
        this.gameObject.SetActive(false);
    }


}
