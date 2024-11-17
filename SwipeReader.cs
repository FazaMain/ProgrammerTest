using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class SwipeReader : MonoBehaviour
{
    bool Go;
    public float StrafeSpeed = 2f;
    public float MinStrafeX;  
    public float MaxStrafeX;   

    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private bool isTouching;
    private float strafeInput;

    private float lastStrafePos = 0f;
    private float smoothStrafeSpeed = 0.1f;
    // не забыть доделать smooth

    private void OnEnable()
    {
        MenuController.LevelBegin += Beginlvl;
        LevelManagerNew.Fail += fail;
        LevelManagerNew.LevelEnd += fail;
        MenuController.RestartPanelActive += GoToggle;
    }
    private void OnDisable()
    {
        MenuController.LevelBegin -= Beginlvl;
        LevelManagerNew.Fail -= fail;
        LevelManagerNew.LevelEnd -= fail;
        MenuController.RestartPanelActive -= GoToggle;
    }
    void GoToggle(bool b)
    {
        b = !b;
        Go = b;
    }
    void fail()
    {
        Go = false;
    }
    void Beginlvl()
    {
        Go = true;
    }
    private void Update()
    {
        if (Go)
        {
            StrafeInput();
        }      
    }

    private void StrafeInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
                isTouching = true;
            }
            else if (touch.phase == TouchPhase.Moved && isTouching)
            {
                touchEndPos = touch.position;
                float deltaX = (touchEndPos.x - touchStartPos.x) / Screen.width;
                strafeInput = deltaX * StrafeSpeed;
                touchStartPos = touchEndPos;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isTouching = false;
            }
        }
        if ((lastStrafePos >= MaxStrafeX && strafeInput > 0) || (lastStrafePos <= MinStrafeX && strafeInput < 0))
        {
            strafeInput = 0;
        }
        lastStrafePos += strafeInput;
        float clampedStrafePos = Mathf.Clamp(lastStrafePos, MinStrafeX, MaxStrafeX);
        float smoothedPosition = Mathf.Lerp(transform.localPosition.x, clampedStrafePos, smoothStrafeSpeed);
        transform.localPosition = new Vector3(smoothedPosition, transform.localPosition.y, transform.localPosition.z);
    }
}
