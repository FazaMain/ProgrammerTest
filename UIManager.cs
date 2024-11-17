using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    
    public Color[] BarColorsArray;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI[] BarTextArray;
    public TextMeshProUGUI FinalScoreText;
    public TextMeshProUGUI ADSScore;
    [Header("Панели")]
    public GameObject FailPanel;
    public GameObject StartPanel;
    public GameObject BarPanel;
    public GameObject LevelAndScorePanel;
    public GameObject FinishPanel;


    public Animator PlayerStatusUpdate;
    public Slider BarSlider;
    public Image SliderFill;


    [Header("обновление при подборе")]
    public TextMeshProUGUI PlusText;
    public Animator PlusAnim;


    //1 30 60 80

    private void OnEnable()
    {
        MenuController.LevelBegin += StartPanelOff;
    }
    private void OnDisable()
    {
        MenuController.LevelBegin -= StartPanelOff;
    }
    public void ScoreUpdate(int i)
    {
        ScoreText.text = "" + i;
        if(i <= 0)
        {
            Fail();
        }
        SliderUpdate(i);
    }
    void SliderUpdate(int i)
    {
        if (i <= 100)
        {
            BarSlider.value = i;
        }
        else
        {
            BarSlider.value = 100;
        }
    }

    public void Fail()
    {
        LevelAndScorePanel.SetActive(false);
        BarPanel.SetActive(false);
        FailPanel.SetActive(true);
    }
    public void StartPanelOff()
    {
        StartPanel.SetActive(false);
        BarPanel.SetActive(true);
        LevelAndScorePanel.SetActive(true);
    }

    public void Finish(int Score)
    {
        LevelAndScorePanel.SetActive(false);
        FinalScoreText.text = Score + "";
        ADSScore.text = Score * 2 + "";
        FinishPanel.SetActive(true);
    }
}
