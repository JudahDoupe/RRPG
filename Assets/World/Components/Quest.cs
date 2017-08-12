using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour {

    public QuestLog Log;

    [HideInInspector]
    public bool IsActive = false;
    public bool IsComplete = false;
    public string Title;
    public Trigger ActivationTrigger;
    public Trigger ResolutionTrigger;

    
    void Start()
    {
        if(ActivationTrigger == null) IsActive = true;
    }

    public void Update()
    {
        if (!IsActive)
        {
            IsActive = ActivationTrigger.IsTripped;
        }
        else if (!IsComplete)
        {
            if(IsComplete = ResolutionTrigger.IsTripped)
                Debug.Log("Completed Quest: " + Title);
        }
    }
}
