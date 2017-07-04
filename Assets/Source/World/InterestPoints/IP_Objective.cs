using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IP_Objective : InterestPoint
{
    public Objective objective;

    public override void Activate(GameObject activator)
    {
        Debug.Log("You have activated a Sign Post");
        FW_Players.Player.GetComponent<PersonalNarritive>().TransferObjective(objective);
        State = ActiveState.Exhausted;
    }
}
