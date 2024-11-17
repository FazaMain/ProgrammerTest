using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSER : MonoBehaviour
{
    int TargetFPS = 60;
    void Awake()
    {
        Application.targetFrameRate = TargetFPS;
    }


}
