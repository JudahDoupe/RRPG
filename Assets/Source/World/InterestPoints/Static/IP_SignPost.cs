using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IP_SignPost : MonoBehaviour, IInterestPoint
{
    public Objective objective;
    public GameObject player;

    private bool ready;

    void Awake()
    {
        ready = true;
    }

    public void OnLeftClick()
    {
        if(ready)Activate(player);
    }

    public void Activate(GameObject activator)
    {
        Debug.Log("You have activated a Sign Post");
        player.GetComponent<PersonalNarritive>().TransferObjective(objective);
        ready = false;
    }
}
