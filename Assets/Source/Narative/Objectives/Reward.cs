using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour{
    public string RewardText = "";

    public virtual Reward Transfer(GameObject newParent)
    {
        var rtn = newParent.AddComponent<Reward>(this);
        Destroy(this);
        return rtn;
    }
}
