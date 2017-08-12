using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : Trigger
{
    public void Interact()
    {
        IsTripped = true;
    }
}
