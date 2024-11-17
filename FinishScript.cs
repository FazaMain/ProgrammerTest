using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FinishScript : MonoBehaviour
{

    LevelManagerNew LM;
    private void Start()
    {
        LM = FindObjectOfType<LevelManagerNew>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LM.Finish();
        }
    }
}
