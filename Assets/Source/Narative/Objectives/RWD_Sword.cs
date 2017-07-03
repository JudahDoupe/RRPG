using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RWD_Sword : Reward
{
    void Awake()
    {
        RewardText = "whimpy sword";
    }

    public override Reward Transfer(GameObject newParent)
    {
        var rtn = newParent.AddComponent<RWD_Sword>(this);
        Destroy(this);
        return rtn;
    }
}
