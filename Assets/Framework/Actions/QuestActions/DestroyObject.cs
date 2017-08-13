using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : Action
{
    public GameObject Target;

    public override void Execute()
    {
        UnityEngine.Object.Destroy(Target);
    }
}
