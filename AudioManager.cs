using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] SoundsArray;
    [SerializeField]
    bool SoundOn = true;

    public void PlaySound(int i)
    {
        if (SoundOn)
        {
            SoundsArray[i].Play();
        }
    }

    public void SoundToggle()
    {
        Debug.Log(SoundOn);
        SoundOn = !SoundOn;
    }
    public void WalckToggle(bool b)
    {
        Walcking = b;
        StartCoroutine(StepCo());
    }
    bool Walcking;
    IEnumerator StepCo()
    {
        while (Walcking)
        {
            SoundsArray[2].Play();
            yield return new WaitForSeconds(0.4f);
        }
    }
}

