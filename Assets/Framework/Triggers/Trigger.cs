using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Trigger : MonoBehaviour
{
    public Action ResponceAction;
    private bool isTripped;
    public bool IsTripped
    {
        get
        {
            return isTripped;
        }
        set
        {
            if (value && ResponceAction != null)
                ResponceAction.Execute();

            isTripped = value;
        }
    }
}
