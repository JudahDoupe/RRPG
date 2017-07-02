using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IP_SignPost : MonoBehaviour, IInterestPoint
{

    private bool ready;

    void Awake()
    {
        ready = true;
    }

    public void OnLeftClick()
    {
        if(ready)Activate();
    }

    public void Activate()
    {
        Debug.Log("You have activated a Sign Post");
        ready = false;
    }
}
