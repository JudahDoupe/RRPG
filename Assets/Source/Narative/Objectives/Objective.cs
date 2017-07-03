using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour{
    public int NarativeImportance = 0;
    public string Title = "";
    public bool Resolved = false;

    public virtual bool IsResolved() { return Resolved; }
    public virtual void Resolve() { Resolved = true; }

    public virtual Objective Transfer(GameObject newParent)
    {
        var rtn = newParent.AddComponent<Objective>(this);
        Destroy(this);
        return rtn;
    }

}
