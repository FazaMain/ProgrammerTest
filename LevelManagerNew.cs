using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManagerNew : MonoBehaviour
{
    public static event Action Fail;
    public static event Action LevelEnd;
    int CurrentScore = 40;
    int Multiplyer = 1;


    public ParticleSystem[] Pickup;
    UIManager  UIM;
    AudioManager AM;
    private void Start()
    {
        UIM = FindObjectOfType<UIManager>();
        AM = FindObjectOfType<AudioManager>();
    }
    private void OnEnable()
    {
        MultiplyerGate.AddMultiply += MultiplyerUpdate;
        GateScript.GateEnter += OnGateEnter;
        PickObjectScript.ObjectPickup += PickupObject;
        MenuController.LevelBegin += LevelStart;
    }
    private void OnDisable()
    {
        MultiplyerGate.AddMultiply -= MultiplyerUpdate;
        GateScript.GateEnter -= OnGateEnter;
        PickObjectScript.ObjectPickup -= PickupObject;
        MenuController.LevelBegin -= LevelStart;
    }

    public void LevelStart()
    {
        AM.WalckToggle(true);
    }
    void PickupObject(bool Plus, int Amount)
    {
        ScoreUpdate(Plus, Amount);
    }
    void OnGateEnter(bool Plus, int Amount)
    {
        ScoreUpdate(Plus, Amount);
    }
    void MultiplyerUpdate(int i)
    {
        Multiplyer = i;
        AM.PlaySound(3);
    }

    void ScoreUpdate(bool Plus,int i)
    {
        if (Plus)
        {
            CurrentScore += i;
            Pickup[0].Play();
            AM.PlaySound(0);
        }
        else
        {
            CurrentScore -= i;
            Pickup[1].Play();
            AM.PlaySound(1);
            if (CurrentScore <= 0)
            {
                AM.PlaySound(6);
                AM.WalckToggle(false);
                Fail?.Invoke();
            }
        }
        UIM.ScoreUpdate(CurrentScore);
    }
    
    
    public void Finish()
    {
        AM.WalckToggle(false);
        AM.PlaySound(5);
        LevelEnd();
        CurrentScore = CurrentScore * Multiplyer;
        UIM.Finish(CurrentScore);
    }
}
