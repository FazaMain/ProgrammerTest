using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MultiplyerGate : MonoBehaviour
{
    public int Multiplyer;

    public Animator DoorAnim;
    public static event Action<int> AddMultiply;
    AudioManager AM;
    private void Start()
    {
        AM = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddMultiply?.Invoke(Multiplyer);
            DoorAction();
        }
    }


    void DoorAction()
    {
        DoorAnim.SetTrigger("Open");
        AM.PlaySound(0);
    }
    
}
