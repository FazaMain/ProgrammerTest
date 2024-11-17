using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] PlayerTypes;


    public void TypeSwitch(int i)
    {
        foreach(GameObject obj in PlayerTypes)
        {
            obj.SetActive(false);
        }
        PlayerTypes[i].SetActive(true);
    }

}
