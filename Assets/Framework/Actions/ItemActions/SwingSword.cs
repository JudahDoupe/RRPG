using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingSword : Action {

    public override void Execute()
    {
        var animator = transform.root.GetComponent<Animator>();
        if(animator != null)
            animator.Play("SwingSword");
    }
}
