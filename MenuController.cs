using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public static event Action LevelBegin;
    public static event Action<bool> RestartPanelActive;
    public GameObject SettingsPanel;
    public GameObject RestartPanel;


    AudioManager AM;
    private void Start()
    {
        AM = FindObjectOfType<AudioManager>();
    }
    public void SettingsPanelToggle(bool State)
    {
        Debug.Log("Настройки");
        uiSound();
        SettingsPanel.SetActive(State);
    }
    public void RestartPanelToggle(bool b)
    {
        uiSound();
        RestartPanel.SetActive(b);
        bool x = !b;
        AM.WalckToggle(x);
        RestartPanelActive?.Invoke(b);
    }

    public void StartLevel()
    {
        uiSound();
        LevelBegin?.Invoke();
    }

    public void NewLvl()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
    public void buttonNoFunc()
    {
        uiSound();
    }
    void uiSound()
    {
        AM.PlaySound(7);
    }
}
