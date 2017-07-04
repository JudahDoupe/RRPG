using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJ_ClickTheSign : Objective
{
    public Reward reward;

    void Start()
    {
        NarativeImportance = 1;
        Title = "Click The Sign!!!";
    }

    public override Objective Transfer(GameObject newParent)
    {
        var rtn = newParent.AddComponent(this);
        Destroy(this);
        return rtn;
    }
    public override void Resolve()
    {
        Debug.Log("Sign Post: 'Thanks for clicking me!'");

        reward = reward.Transfer(gameObject);

        Resolved = true;
    }
}
