using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{

    public Animator Anim;
    AudioManager AM;
    private void Start()
    {
        AM = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Anim.SetTrigger("HoistTheColors");
            AM.PlaySound(4);
        }
    }



}
