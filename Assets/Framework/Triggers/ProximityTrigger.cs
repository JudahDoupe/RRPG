using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityTrigger : Trigger
{
    public float ProximityDistance = 5.0f;
    public Transform Target;

    void Update()
    {
        IsTripped = Vector3.Distance(Target.transform.position, transform.position) <= ProximityDistance;
    }
}
